namespace Stealer
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string info = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(info);
        }
    }
}
