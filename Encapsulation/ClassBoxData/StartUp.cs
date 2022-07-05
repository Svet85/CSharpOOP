using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double len = double.Parse(Console.ReadLine());
            double wid = double.Parse(Console.ReadLine());
            double hei = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(len, wid, hei);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
            catch ( Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
