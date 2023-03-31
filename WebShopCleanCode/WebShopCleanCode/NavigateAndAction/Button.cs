using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode
{
    public class Button
    {
        ICommand command;
        
        public string Name { get; set; }
        public Button(ICommand command)
        {
            this.command = command;
            
        }

        public void PushButton(int currentChoice)
        {
            command.Execute(currentChoice);
        }
    }
}
