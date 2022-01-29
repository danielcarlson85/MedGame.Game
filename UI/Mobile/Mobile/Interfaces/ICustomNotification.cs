using System;
using System.Collections.Generic;
using System.Text;

namespace MedGame.UI.Interfaces
{
    public interface ICustomNotification
    {
        void Send(string title, string message);
    }
}
