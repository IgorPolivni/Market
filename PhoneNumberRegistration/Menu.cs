using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberRegistration
{
    public class Menu
    { 
        public static bool MainMenu(string[] users)
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("\t1.Регистрация");
            Console.WriteLine("\t2.Выход");
            Console.Write("Введите номер действия: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите номер телефона по шаблону (+XXXXXXXXXXX): ");

                    var phoneNumber = Console.ReadLine();

                    RegistrationService _registrationService = new RegistrationService();
                    var varifyCode = _registrationService.Registration(phoneNumber, users);

                    if (varifyCode != null)
                    {

                        Console.Write("Введите код из SMS: ");
                        while (Console.ReadLine() != varifyCode)
                        {
                            Console.WriteLine("Неверный код, попробуйте еще раз.");
                        }

                        Array.Resize(ref users, users.Length + 1);
                        users[users.Length - 1] = phoneNumber;

                        Console.WriteLine("Добро пожаловать!");
                        Console.Read();
                    }

                    else
                    {
                        Console.WriteLine("Возникла ошибка регистрации. Возможно, данный номер уже зарегистрирован в системе.");
                    }

                    return true;

                case "2":
                    return false;

                default:
                    return true;
            }
        }
    }
}
