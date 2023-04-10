using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode
{
    public class Button
    {
        private readonly ICommand _command;
        
        public Button(ICommand command)
        {
            _command = command;
        }

        public void PushButton(int currentChoice)
        {
            _command.Execute(currentChoice);
        }
    }
}
