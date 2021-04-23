using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Account
{
    public class AccountService
    {
        public bool IsSignedIn()
        {
            return true;
        }
    }
}
