using Cars.Context;
using Cars.Services;

namespace Cars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                CarService carService = new CarService(context);

                var car1 = carService.GetModelById(1);
                var car2 = carService.GetModelById(2);

                Console.WriteLine(car1.Car);
                Console.WriteLine(car2.Car);

                if (car1.MaxSpeed > car2.MaxSpeed)
                {
                    Console.WriteLine($"The first car: {car1.Name} is faster than the second: {car2.Name}");
                }
                else if (car1.MaxSpeed < car2.MaxSpeed)
                {
                    Console.WriteLine($"The second car: {car2.Name} is faster than the first: {car1.Name}");
                }
                else 
                {
                    Console.WriteLine("The cars are equally fast.");
                }


                if (car1.Length > car2.Length)
                {
                    Console.WriteLine($"The first car: {car1.Name} is longer than the second: {car2.Name}");
                }
                else if (car1.Length < car2.Length)
                {
                    Console.WriteLine($"The second car: {car2.Name} is longer than the first: {car1.Name}");
                }
                else
                {
                    Console.WriteLine("The cars are equally long.");
                }
            }
        }
    }
}
