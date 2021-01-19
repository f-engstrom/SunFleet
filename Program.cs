using System;
using System.ComponentModel.Design;
using System.Threading;
using System.Xml.Schema;


namespace SunFleet
{
    class Program
    {
        static void Main(string[] args)
        {
            SunFleetCars mySunFleetCars = new SunFleetCars();
            mySunFleetCars.Menu();

        }
    }

    class ANewCar
    {
        public string RegistrationNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; }
        public bool IsChared { get; set; }

        public ANewCar(string registrationNumber, string brand, string model, string carType)
        {
            RegistrationNumber = registrationNumber;
            Brand = brand;
            Model = model;
            CarType = carType;

        }

        public override string ToString()
        {
            return RegistrationNumber.PadLeft(5, ' ') + Model.PadLeft(15, ' ');
        }
    }

    class SunFleetCars
    {
        public ANewCar[] myCars = new ANewCar[10];
        private int newCarArrayPos;


        public void Menu()
        {

            int menuChoice = 8;

            do
            {
                menuChoice = 0;
                Console.Clear();
                Console.WriteLine("1. Add car");
                Console.WriteLine("2. List cars");
                Console.WriteLine("3. Charge car");
                Console.WriteLine("4. Exit");




                ConsoleKeyInfo UserInput = Console.ReadKey(true);

                if (char.IsDigit(UserInput.KeyChar))
                {
                    menuChoice = int.Parse(UserInput.KeyChar.ToString());

                }
                else
                {
                    menuChoice = -1;
                }

                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();
                        AddCar();
                        break;

                    case 2:
                        Console.Clear();
                        ShowMeTheCars();
                        break;

                    case 3:
                        Console.Clear();
                        ChargeCar();
                        break;

                }


            } while (menuChoice != 4);

        }

        public void AddCar()
        {
            bool lisencePlateExists = false;

            Console.SetCursorPosition(5, 5);
            Console.Write("Registration number: ");
            Console.SetCursorPosition(5, 7);
            Console.Write("Brand: ");
            Console.SetCursorPosition(5, 9);
            Console.Write("Model: ");
            Console.SetCursorPosition(5, 11);
            Console.Write("Car type: ");
            Console.SetCursorPosition("Registration number: ".Length + 5, 5);
            string registrationNumber = Console.ReadLine();
            Console.SetCursorPosition("Brand: ".Length + 5, 7);
            string brand = Console.ReadLine();
            Console.SetCursorPosition("Model: ".Length + 5, 9);
            string model = Console.ReadLine();
            Console.SetCursorPosition("Car type: ".Length + 5, 11);
            string carType = Console.ReadLine();

            foreach (var car in myCars)
            {
                if (car == null)
                {
                    continue;
                }

                if (car.RegistrationNumber == registrationNumber)
                {
                    lisencePlateExists = true;
                }

            }

            if (lisencePlateExists)
            {
                Console.Clear();
                Console.WriteLine("License plate already exits");
                Thread.Sleep(1000);
            }
            else
            {
                myCars[newCarArrayPos] = new ANewCar(registrationNumber, brand, model, carType);
                Console.Clear();
                Console.WriteLine("Car added");
                newCarArrayPos++;
                Thread.Sleep(1000);

            }



        }

        public void ShowMeTheCars()
        {

            Console.SetCursorPosition(0, 5);
            Console.Write("Registration Number".PadLeft(20, ' ') + "type".PadLeft(10, ' ') +
                          "Is charged\n".PadLeft(20, ' '));
            Console.WriteLine(" ".PadLeft(60, '-'));
            Console.SetCursorPosition(0, 10);

            foreach (var car in myCars)
            {


                if (car == null)
                {
                    continue;
                }

                if (car.IsChared)
                {
                    Console.WriteLine(car + "Yes".PadLeft(30, ' '));

                }
                else
                {
                    Console.WriteLine(car + "No".PadLeft(30, ' '));

                }


            }

            Console.WriteLine("\n\n\nPress any key to continue");
            Console.ReadKey();
        }

        public void ChargeCar()
        {

            bool carExists = false;
            int arrayPos = 0;
            int tempArrayPos = 0;

            Console.SetCursorPosition(5, 5);
            Console.Write("Registration number: ");
            Console.SetCursorPosition("Registration number: ".Length + 5, 5);
            string registrationNumber = Console.ReadLine();


            Console.Clear();

            foreach (var car in myCars)
            {
                if (car == null)
                {
                    continue;
                }

                if (car.RegistrationNumber == registrationNumber)
                {
                    carExists = true;
                    arrayPos = tempArrayPos;

                }

                tempArrayPos++;

            }

            if (carExists)
            {
                myCars[arrayPos].IsChared = true;
                Console.WriteLine("Car charged");
                Thread.Sleep(1000);

            }

            else
            {

                Console.WriteLine("Car not found");
                Thread.Sleep(1000);
            }
        }

    }
}
