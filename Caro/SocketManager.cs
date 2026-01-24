using System.Net.Sockets;
using System.Text;
using System.Threading;

public class SocketManager
{
    TcpClient client;
    NetworkStream stream;

    public bool Connect(string ip)
    {
        // ❗ Check IP
        if (!ip.StartsWith("127.0.0."))
            return false;

        client = new TcpClient();
        client.Connect(ip, 9999);
        stream = client.GetStream();
        return true;
    }

    public void Send(string data)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(data);
        stream.Write(buffer, 0, buffer.Length);
    }

    public string Receive()
    {
        byte[] buffer = new byte[1024];
        int bytes = stream.Read(buffer, 0, buffer.Length);
        return Encoding.UTF8.GetString(buffer, 0, bytes);
    }
}
