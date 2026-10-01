using System.Net;
using System.Net.Sockets;
using Serilog;

namespace MSC02.Services;

public class GatewayListener
{
    public async Task StartAsync()
    {
        // ایجاد شنونده برای ارتباط با گیت‌وی روی درگاه ۶۰۰۰
        TcpListener listener = new TcpListener(
            IPAddress.Loopback,
            6000);

        // شروع گوش دادن
        listener.Start();

        Console.WriteLine("ام‌اس‌سی‌۰۲: منتظر اتصال گیت‌وی هستم...");

        // برنامه همیشه منتظر گیت‌وی بعدی می‌ماند
        while (true)
        {
            // منتظر ماندن تا گیت‌وی متصل شود
            TcpClient client = await listener.AcceptTcpClientAsync();

            Console.WriteLine("ام‌اس‌سی‌۰۲: گیت‌وی متصل شد.");

            // ایجاد فضای موقت برای داده‌های دریافتی
            byte[] buffer = new byte[1024];

            // خواندن داده از ارتباط
            int bytesRead = await client.GetStream().ReadAsync(buffer);

            // تبدیل داده‌های دریافتی به متن
            string telegram = System.Text.Encoding.UTF8.GetString(
                buffer,
                0,
                bytesRead);

            // ثبت تلگرام دریافت‌شده
            Log.Information(
                "تلگرام دریافت شد: {Telegram}",
                telegram);

            try
            {
                // جدا کردن مقدار دما از تلگرام
                string temperatureText = telegram.Split('|')[1];

                // تبدیل مقدار دما از متن به عدد
                int temperature = int.Parse(temperatureText);

                // ذخیره آخرین دمای دریافت‌شده
                TemperatureStore.CurrentTemperature = temperature;

                // ثبت اطلاعات دما
                Log.Information(
                    "تلگرام دریافت شد | گیت‌وی: {Gateway} | نوع: {Type} | دما: {Temperature}",
                    "GW01",
                    "TEMP",
                    temperature);
            }
            catch (Exception ex)
            {
                // ثبت خطای پردازش تلگرام
                Log.Error(
                    ex,
                    "خطا در پردازش تلگرام: {Telegram}",
                    telegram);
            }

            // بستن ارتباط با گیت‌وی
            client.Close();

            Console.WriteLine(
                "ام‌اس‌سی‌۰۲: منتظر تلگرام بعدی هستم...");
        }
    }
}