using System.Net;
using System.Net.Sockets;

namespace MSC02.Services;

public class GatewayListener
{
    public async Task StartAsync()
    {
        TcpListener listener = new TcpListener(IPAddress.Loopback, 6000);

        listener.Start();

        Console.WriteLine("MSC02: منتظر اتصال Gateway هستم...");

        TcpClient client = await listener.AcceptTcpClientAsync();

        Console.WriteLine("MSC02: Gateway متصل شد.");

        byte[] buffer = new byte[1024];

        int bytesRead = await client.GetStream().ReadAsync(buffer);

        string telegram = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

        Console.WriteLine($"MSC02: Telegram دریافت شد: {telegram}");
    }
}