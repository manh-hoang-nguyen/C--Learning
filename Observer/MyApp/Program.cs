using System;
using System.Collections.Generic;
using SuperCoolLibrary.CoolStuff;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameManager = new NameManager();

            nameManager.OnNotification += NameManagerOnOnNotification;

            var possibleNames = new List<string> {"Fred", "George", "Jon", "Daphne"};

            foreach (var name in possibleNames)
            {
                var result = nameManager.GetModel(name);

                Console.WriteLine($"{result.Name} is from {result.FriendlyName}!");
            }

            Console.ReadKey();
        }

        private static void NameManagerOnOnNotification(object sender, NotificationEventArg notificationEventArg)
        {
            //log the message
            Console.WriteLine(notificationEventArg.Message);
        }
    }
}
