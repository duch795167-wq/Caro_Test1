using System;
using System.Net;
using System.Net.Sockets;
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
        NetworkStream s1 = p1.GetStream();
        NetworkStream s2 = p2.GetStream();

        // Phân lượt
        Send(p1, "START|O\n"); // p1 đi trước
        Send(p2, "START|X\n");

        try
        {
            while (true)
            {
                // Nhận từ player 1 → gửi cho player 2
                if (s1.DataAvailable)
                {
                    string msg = Receive(s1);
                    if (msg == null) break;

                    Console.WriteLine("P1: " + msg.Trim());
                    Send(p2, msg);
                }

                // Nhận từ player 2 → gửi cho player 1
                if (s2.DataAvailable)
                {
                    string msg = Receive(s2);
                    if (msg == null) break;

                    Console.WriteLine("P2: " + msg.Trim());
                    Send(p1, msg);
                }

                Thread.Sleep(1); // tránh CPU 100%
            }
        }
        catch
        {
            Console.WriteLine("Mot nguoi choi da thoat");
        }
        finally
        {
            p1.Close();
            p2.Close();
        }
    }

    static void Send(TcpClient client, string msg)
    {
        byte[] data = Encoding.UTF8.GetBytes(msg);
        client.GetStream().Write(data, 0, data.Length);
    }

    static string Receive(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];
        int bytes = stream.Read(buffer, 0, buffer.Length);
        if (bytes <= 0) return null;
        return Encoding.UTF8.GetString(buffer, 0, bytes);
    }
}
