using System;

namespace SuperCoolLibrary.CoolStuff
{
    public delegate void NotificationHandler(object sender, NotificationEventArg e);

    public interface INameManager
    {
        event NotificationHandler OnNotification;
        PopCultureNameModel GetModel(string name);
    }
}
