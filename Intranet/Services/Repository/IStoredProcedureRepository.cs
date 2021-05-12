using Intranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Repository
{
    public interface IStoredProcedureRepository
    {
        List<IT_AUTORIZACION> Sp_Commissions(string User = null, string Phrase = null, Nullable<DateTime> StartDate = null, Nullable<DateTime> EndDate = null, Nullable<int> Size = null, Nullable<int> Page = null);
    }
}
