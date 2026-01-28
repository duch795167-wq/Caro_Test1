using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

class Program
{
    
    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 9999);
        server.Start();
        Console.WriteLine("Server dang cho 2 nguoi choi...");

        while (true)
        {
            TcpClient player1 = server.AcceptTcpClient();
            Console.WriteLine("Player 1 da ket noi");
            Send(player1, "WAIT\n");

            TcpClient player2 = server.AcceptTcpClient();
            Console.WriteLine("Player 2 da ket noi");
            Send(player2, "WAIT\n");

            Console.WriteLine("Da ghep doi 2 nguoi choi");

            Thread gameThread = new Thread(() => HandleGame(player1, player2));
            gameThread.IsBackground = true;
            gameThread.Start();
            
        }
    }

    static void HandleGame(TcpClient p1, TcpClient p2)
    {
        

        try
        {
            NetworkStream s1 = p1.GetStream();
            NetworkStream s2 = p2.GetStream();

            string roomname = RoomName();

            // Phân lượt
            Send(p1, "START|O|"+ roomname + "\n"); // p1 đi trước
            Thread.Sleep(100);
            Send(p2, "START|X|"+ roomname + "\n");



            while (true)
            {

                // Nhận từ player 1 → gửi cho player 2
                
                

                if (s1.DataAvailable)
                {
                    string msg1 = Receive(s1);
                    
                    if (msg1.StartsWith("OUT"))
                    {
                        Send(p2, "OUT|Người chơi 1 đã thoát");
                        p2.Close();
                        break;
                    }

                    if (msg1.StartsWith("CHAT"))
                    {
                        Send(p2, msg1);
                    }

                    if (msg1.StartsWith("MOVE"))
                    {
                        Send(p2, msg1);
                    }
                    else if (msg1.StartsWith("TIMEOUT"))
                    {

                        Send(p1, "TIMEOUT|P1\n");
                        Send(p2, "TIMEOUT|P1\n");
                        Thread.Sleep(100);
                    }
                    else if (msg1.StartsWith("ENDGAME"))
                    {
                        Send(p1, "WIN|P1\n");
                        Send(p2, "WIN|P1\n");
                    }
                }

                // Nhận từ player 2 → gửi cho player 1
                if (s2.DataAvailable)
                {
                    string msg2 = Receive(s2);
                    if (msg2.StartsWith("OUT"))
                    {
                        Send(p1, "OUT|Người chơi 2 đã thoát");
                        p1.Close();
                        break;
                    }

                    if (msg2.StartsWith("CHAT"))
                    {
                        Send(p1, msg2);
                    }

                    if (msg2.StartsWith("MOVE"))
                    {
                        Send(p1, msg2);
                    }
                    else if (msg2.StartsWith("TIMEOUT"))
                    {

                        Send(p1, "TIMEOUT|P2\n");
                        Send(p2, "TIMEOUT|P2\n");
                        Thread.Sleep(100);

                    }
                    else if (msg2.StartsWith("ENDGAME"))
                    {
                        Send(p1, "WIN|P2\n");
                        Send(p2, "WIN|P2\n");
                    }
                    
                }

                Thread.Sleep(10); // tránh CPU 100%
            }
        }
        catch
        {
            Console.WriteLine("Lỗi kết nối");

            
        }
        finally
        {
            p1.Close();
            Console.WriteLine("Đã ngắt kết nối Player1");
            p2.Close();
            Console.WriteLine("Đã ngắt kết nối Player2");
        }
    }

    static void Send(TcpClient client, string msg)
    {
        byte[] data = Encoding.UTF8.GetBytes(msg);
        client.GetStream().Write(data, 0, data.Length);
    }

    static string Receive(NetworkStream stream)
    {
        try
        {
            byte[] buffer = new byte[1024];
            int bytes = stream.Read(buffer, 0, buffer.Length);
            if (bytes <= 0) return null;
            return Encoding.UTF8.GetString(buffer, 0, bytes);
        }

        catch
        {
            return null;
        }
        
    }


    static string RoomName()
    {
        Random rd = new Random();

        return "CARO-" + rd.Next(1000, 9999);
    }
}
