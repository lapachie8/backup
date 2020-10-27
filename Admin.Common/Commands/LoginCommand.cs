using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Common.Commands
{
    public class LoginCommand
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}
