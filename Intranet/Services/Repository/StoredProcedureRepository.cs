using Intranet.Data;
using Intranet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Repository
{
    public class StoredProcedureRepository: IStoredProcedureRepository
    {
        internal ApplicationDbContext context;
        public StoredProcedureRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        List<IT_AUTORIZACION> IStoredProcedureRepository.Sp_Commissions(string User = null, string Phrase = null, Nullable <DateTime> StartDate = null, Nullable<DateTime> EndDate = null, Nullable<int> Size = null, Nullable<int> Page = null)
        {
            var result = this.context.IT_AUTORIZACION.FromSqlRaw<IT_AUTORIZACION>("Sp_Commissions {0},{1},{2},{3},{4},{5}"
                , StartDate.HasValue ? StartDate.Value : null
                , EndDate.HasValue ? EndDate.Value : null
                , Size.HasValue ? Size.Value : null
                , Page.HasValue ? Page.Value : null
                , User
                , Phrase
                ).ToList();
            return result;
        }

    }
}
