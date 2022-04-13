using Scheduler.Models;
using Scheduler.Services.Auth;
using System;

namespace Scheduler.Screens
{
    class MainScreen
    {
        ReceptionistScreen _receptionistScreen;
        DoctorScreen _doctorScreen;
        PatientScreen _patientScreen;

        public MainScreen()
        {
            _receptionistScreen = new ReceptionistScreen();
            _doctorScreen = new DoctorScreen();
            _patientScreen = new PatientScreen();
        }

        public void Show()
        {
            while (true)
            {
                WelcomeMessage();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nKyquni [kyqu]\n" +
                    "Regjistrohuni si pacient [regjistrohu]\n" +
                    "Rreth nesh [rreth]\n" +
                    "Dilni [dil]");
                Console.ResetColor();
                Console.Write("\n> ");

                var command = Console.ReadLine().Trim().ToLower();

                if (command == "kyqu")
                    Login();
                else if (command == "regjistrohu")
                    Register();
                else if (command == "rreth")
                    About();
                else if (command == "dil")
                    return;
                else
                    continue;
            }
        }

        void WelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*******************************");
            Console.WriteLine("***                         ***");
            Console.WriteLine("*** Mire se vini ne {0} ***", Config.Name);
            Console.WriteLine("***                         ***");
            Console.WriteLine("*******************************");
        }

        void Login()
        {
            Console.Write("  Emri i perdoruesit: ");
            var username = Console.ReadLine();

            Console.Write("  Fjalekalimi: ");
            var password = ReadPassword();
            var user = LoginService.Login(username, password);

            if (user is Receptionist receptionist)
                _receptionistScreen.Show(receptionist);
            else if (user is Doctor doctor)
                _doctorScreen.Show(doctor);
            else if (user is Patient patient)
                _patientScreen.Show(patient);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nKredencialet jane te gabuara!");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        void Register()
        {
            Console.Write("  Emri: ");
            var firstName = Console.ReadLine();
            Console.Write("  Mbiemri: ");
            var lastName = Console.ReadLine();
            Console.Write("  Gjinia: ");
            var gender = Console.ReadLine();
            Console.Write("  Emri i perdoruesit: ");
            var username = Console.ReadLine();
            Console.Write("  Fjalekalimi: ");
            var password = ReadPassword();
            Console.Write("\n  Konfirmo fjalekalimin: ");
            var confirmPassword = ReadPassword();

            if (Validate(firstName, lastName, gender, username, password, confirmPassword) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nDuhet te jepen te gjitha te dhenat e kerkuara!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            if (password != confirmPassword)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nFjalekalimi nuk eshte i njejte!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            RegisterService.Register(firstName, lastName, gender, username, password);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nRegjistrimi u krye me sukses.");
            Console.ReadKey();
        }

        void About()
        {
            WelcomeMessage();

            Console.WriteLine(Config.AboutUs);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Shtyp Enter per t'u kthyer ne balline...");
            Console.ReadKey();
        }

        bool Validate(
            string firstName,
            string lastName,
            string gjinia,
            string username,
            string password,
            string confirmPassword)
        {
            return !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)
                || string.IsNullOrEmpty(gjinia) || string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword));
        }

        string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            return password;
        }
    }
}