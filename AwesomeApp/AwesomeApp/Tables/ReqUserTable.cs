using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeApp.Tables
{
    internal class ReqUserTable
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
