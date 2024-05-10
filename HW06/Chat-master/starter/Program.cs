using System.Diagnostics;

namespace starter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Process.Start(new ProcessStartInfo
            {
                Arguments = "/C/Users/Aliaksandr/Documents/GB/CSharp_net_dev/HW07/Chat-master/Chat/bin/Debug/net8.0/Chat.exe",
                FileName = @"cmd",
                UseShellExecute = false
            });
           
            Process.Start(new ProcessStartInfo
            {
                Arguments = "/C/Users/Aliaksandr/Documents/GB/CSharp_net_dev/HW07/Chat-master/Chat/bin/Debug/net8.0/Chat.exe Alex 127.0.0.1",
                FileName = @"cmd",
                UseShellExecute = true
            });

            Process.Start(new ProcessStartInfo
            {
                Arguments = "/C/Users/Aliaksandr/Documents/GB/CSharp_net_dev/HW07/Chat-master/Chat/bin/Debug/net8.0/Chat.exe Petr 127.0.0.1",
                FileName = @"cmd",
                UseShellExecute = true
            });
        }
    }
}
//Process.Start(new ProcessStartInfo
//{
//    Arguments = "",
//    FileName = @"c:\Users\Aliaksandr\Documents\GB\CSharp_net_dev\HW07\Chat-master\Chat\bin\Debug\net8.0\Chat.exe"
//});
//Process.Start(new ProcessStartInfo
//{
//    Arguments = "Alex 127.0.0.1",
//    FileName = @"c:\Users\Aliaksandr\Documents\GB\CSharp_net_dev\HW07\Chat-master\Chat\bin\Debug\net8.0\Chat.exe"
//});
//Process.Start(new ProcessStartInfo
//{
//    Arguments = "Viktor 127.0.0.1 12345",
//    FileName = @"c:\Users\Aliaksandr\Documents\GB\CSharp_net_dev\HW07\Chat-master\Chat\bin\Debug\net8.0\Chat.exe"
//});
