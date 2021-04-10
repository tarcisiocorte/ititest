using System;
using System.Collections.Generic;
using System.Text;

namespace Iti.Domain.Entities
{
    public class EntityPassword
    {
        public EntityPassword()
        {

        }
        public EntityPassword(string password)
        {
            this.Password = password;
        }
        public string Password { get; set; }
    }
}
