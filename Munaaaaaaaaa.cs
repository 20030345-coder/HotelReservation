using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydneyHotel
{
    class Program
    {
        class ReservationDetail
        {
            public string customerName { get; set; }
            public int nights { get; set; }
            public string roomService { get; set; }
            public double totalPrice { get; set; }

            public void CalculatePrice()
            {
                double price = 0;
                if (nights >= 1 && nights <= 3)
                    price = 100 * nights;
                else if (nights >= 4 && nights <= 10)
                    price = 80.5 * nights;
                else if (nights >= 11 && nights <= 20)
                    price = 75.3 * nights;
                if (roomService.ToLower() == "yes")
                    price = price + price * 0.1;
                totalPrice = price;
            }
        }

        // calculation of room services
        // Pujan Budathoki
        static double Price(int night, string isRoomService)
        {
            double price = 0;
            if ((night > 0) && (night <= 3))
                price = 100 * night;
            else if ((night > 3) && (night <= 10))
                price = 80.5 * night;
            else if ((night > 10) && (night <= 20))
                price = 75.3 * night;
            //roomservice should be checked to lower yes
            if (isRoomService.ToLower() == "yes")
                return price + price * 0.1;
            else
                return price;

        }
        static ReservationDetail GetCustomerDetails()
        {
            ReservationDetail rd = new ReservationDetail();
            Console.Write("Enter customer name: ");
            rd.customerName = Console.ReadLine();
            Console.Write("Enter the number of nights: ");
            rd.nights = Convert.ToInt32(Console.ReadLine());
            while (rd.nights < 1 || rd.nights > 20)
            {
                Console.Write("Invalid! Enter number of nights (1 to 20): ");
                rd.nights = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Enter yes/no for room service: ");
            rd.roomService = Console.ReadLine();
            rd.totalPrice = Price(rd.nights, rd.roomService);
            return rd;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(".................Welcome to Sydney Hotel................");
            Console.Write("\nEnter no. of Customer: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n-------------------------------------------------------------------\n");
            List<ReservationDetail> rd = new List<ReservationDetail>();

            for (int i = 0; i < n; i++)
            {
                rd.Add(GetCustomerDetails());
            }

            var (minPrice, minindex) = rd.Select(x => x.totalPrice).Select((m, i) => (m, i)).Min();
            var (maxPrice, maxindex) = rd.Select(x => x.totalPrice).Select((m, i) => (m, i)).Max();

            ReservationDetail maxrd = rd[maxindex];
            ReservationDetail minrd = rd[minindex];

            Console.WriteLine("\n\t\t\t\tSummary of reservation");
            Console.WriteLine("-------------------------------------------------------------------\n");
            Console.WriteLine("Name\t\tNumber of nights\t\tRoom service\t\tCharge");
            Console.WriteLine($"{minrd.customerName}\t\t\t{minrd.nights}\t\t\t{minrd.roomService}\t\t\t\t{minrd.totalPrice}");
            Console.WriteLine($"{maxrd.customerName}\t\t{maxrd.nights}\t\t\t{maxrd.roomService}\t\t\t\t{maxrd.totalPrice}");
            Console.WriteLine("\n-------------------------------------------------------------------");
            Console.WriteLine($"The customer spending most is {maxrd.customerName} ${maxrd.totalPrice}");
            Console.WriteLine($"The customer spending least is {minrd.customerName} ${minrd.totalPrice}");
            Console.WriteLine($"Press any key to continue....");
        }

