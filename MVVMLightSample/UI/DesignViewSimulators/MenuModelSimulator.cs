using System.Collections.Generic;
using System.Windows;
using Interfaces.Model.Classes;
using Interfaces.Model.Interfaces;

namespace UI.DesignViewSimulators
{
    internal class MenuModelSimulator : IMenuModel
    {
        public IList<IButtonModel> MenuButtonCommands => new List<IButtonModel>
        {
            new ButtonModel ("Button 1", (s, a) => MessageBox.Show("Button 1 pressed")),
            new ButtonModel ("Button 2", (s, a) => MessageBox.Show("Button 2 pressed")),
            new ButtonModel ("Button 3", (s, a) => MessageBox.Show("Button 3 pressed")),
            new ButtonModel ("Button 4", (s, a) => MessageBox.Show("Button 4 pressed")),
        };
    }
}