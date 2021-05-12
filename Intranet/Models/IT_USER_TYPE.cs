using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models
{
    public class IT_USER_TYPE
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("USER_TYPE_ID", TypeName = "numeric(6,0)")]
        public decimal USER_TYPE_ID { get; set; }
        public string USER_TYPE_NAME { get; set; }
    }
}
