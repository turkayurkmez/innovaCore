using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
   public class FakeUserService
    {
        private List<User> users = new List<User>
        {
            new User { Id=1, UserName="kadir", Password="123", Role="Admin"},
            new User { Id=2, UserName="sevgin", Password="123", Role="Editor"},
            new User { Id=3, UserName="turkay", Password="123", Role="Standart"}


        };
        public User Validate(string userName, string password)
        {
            return users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
