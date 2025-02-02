using Inoa_Willian;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var email = new Email();
        email.GetMail("C:\\Git\\Will\\Inoa_Willian\\config.txt");
        email.SendMail();
    }
}