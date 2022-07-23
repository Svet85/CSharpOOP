namespace Stealer
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string info = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(info);
        }
    }
}
