using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class ActiveDirectoryUserVM
    {
        public int ACTIVE_DIRECTORY_USER_ID { get; set; }
        public string DNI { get; set; }
        public string Display_Name { get; set; }
        public string Email_Address { get; set; }
        public decimal USER_TYPE_ID { get; set; }
    }
}
