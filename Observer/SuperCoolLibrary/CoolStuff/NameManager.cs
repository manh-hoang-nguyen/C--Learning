using System;
using System.Collections.Generic;
using SuperCoolLibrary.CoolStuff.NameCheckers;

namespace SuperCoolLibrary.CoolStuff
{
    public class NameManager : INameManager
    {
        public event NotificationHandler OnNotification;

        public PopCultureNameModel GetModel(string name)
        {
            //logging - name to check
            _notify($"Checking '{name}'...");

            var nameCheckers = new List<ICheckNames>
            {
                new ScoobyDooNameChecker(),
                new SmurfNameChecker(),
                new GameOfThronesChecker()
            };

            foreach (var nameChecker in nameCheckers)
            {
                //logging - current name checker
                _notify($"Using checker '{nameChecker.FriendlyName}'...");

                if (nameChecker.CheckName(name))
                {
                    //logging - we have a match
                    _notify($"We matched!");

                    return new PopCultureNameModel
                    {
                        Name = name,
                        NameChecker = nameChecker.GetType().Name,
                        FriendlyName = nameChecker.FriendlyName
                    };
                }
                else
                {
                    _notify($"We did not match!");
                }
            }

            //logging - we didn't find anything!
            _notify($"We have no idea!");

            return new PopCultureNameModel
            {
                Name = name,
                NameChecker = "Unknown",
                FriendlyName = "Unknown!"
            };
        }

        private void _notify(string message)
        {
            if (OnNotification != null)
            {
                OnNotification.Invoke(this, new NotificationEventArg
                {
                    Message = message
                });
            }
        }
    }
}
