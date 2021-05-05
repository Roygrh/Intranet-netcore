using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models
{
    public class IT_AREA_FUNCIONAL
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("AREA_FUNCIONAL_ID", TypeName = "numeric(6,0)")]
        public decimal AREA_FUNCIONAL_ID { get; set; }
        public string NOMBRE_AREA_FUNCIONAL { get; set; }
    }
}
