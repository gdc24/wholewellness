using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.ViewModels
{
    public class NewUserVM : User
    {
        public User user { get; set; }
    }
}