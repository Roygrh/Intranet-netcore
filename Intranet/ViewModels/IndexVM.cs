using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class IndexVM
    {
        public AuthorizationVM Authorization { get; set; }
        public List<AuthorizationVM> Authorizations { get; set; }
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
    }
}
