using ChatApp;
using ChatNetwork;
using System.Diagnostics;



if (args.Length <= 1)
{
    var messageSource = new MessageSource(12345);
    if (args.Length == 1)
    {
        messageSource = new MessageSource(int.Parse(args[0]));
    }
    var server = new ChatServer(messageSource);
    Console.WriteLine(messageSource._udpClient.Client.LocalEndPoint);
    server.WorkAsync();

}
else if (args.Length >= 2)
{
    var name = args[0];
    var messageSource = new MessageSource(args[1], 12345);
    if (args.Length == 3)
    {
        messageSource = new MessageSource(args[1], int.Parse(args[2]));
    }
    Console.WriteLine(name);
    var client = new ChatClient(name, messageSource);
    client.Start();
}
else
{
    Console.WriteLine("Error. Input name and port.");
}