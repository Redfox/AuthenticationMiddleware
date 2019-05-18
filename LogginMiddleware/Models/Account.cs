using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogginMiddleware.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public bool IsAdmin { get; set; }
    }
}
            