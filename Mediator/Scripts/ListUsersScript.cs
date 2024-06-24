using Mediator.Mediators;
using Mediator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Scripts
{
    public class ListUsersScript : IDisposable
    {
        private readonly UserMediator _userMediator;

        public ListUsersScript(UserMediator userMediator)
        {
            _userMediator = userMediator;

            _userMediator.UserCreated += UserMediator_UserCreated;
        }

        public void Run()
        {
            Console.WriteLine();

            Console.WriteLine("USERS");
            foreach (User user in _userMediator.Users)
            {
                Console.WriteLine(user);
            }
            
            Console.WriteLine();
        }

        public void Dispose()
        {
            _userMediator.UserCreated -= UserMediator_UserCreated;
        }

        private void UserMediator_UserCreated(User newUser)
        {
            Run();
        }
    }
}
