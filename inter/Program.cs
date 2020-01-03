using System;
using inter.Entities;
using System.Globalization;
using inter.Services;

namespace inter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime pickup = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Enter price per hour: ");
            double PerHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double Perday = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            CarRental car = new CarRental(pickup, finish, new Vehicle(model));
            RentalService rental = new RentalService(PerHour, Perday,new BrazilTaxService());

            rental.processInvoice(car);

            Console.WriteLine("Invoice");
            Console.WriteLine(car.Invoice);
        }
    }
}
