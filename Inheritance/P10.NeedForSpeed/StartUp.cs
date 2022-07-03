namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var veh = new Vehicle(10, 200);
            var car = new Car(10, 200);
            var fcar = new FamilyCar(10, 200);
            var motor = new Motorcycle(10, 200);
            var rmotor = new RaceMotorcycle(10, 200);
            var cross = new CrossMotorcycle(10, 200);

            veh.Drive(10);
            car.Drive(10);
            fcar.Drive(10);
            motor.Drive(10);
            rmotor.Drive(10);
            cross.Drive(10);

            System.Console.WriteLine();

        }
    }
}
