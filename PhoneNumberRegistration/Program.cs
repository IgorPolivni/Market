using System;

namespace PhoneNumberRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] users = new string[0];

            bool showMenu = true;
            while(showMenu)
            {
                showMenu = Menu.MainMenu(users);
            }
        }
    }
}
