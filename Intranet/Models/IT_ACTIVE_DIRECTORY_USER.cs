using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models
{
    public class IT_ACTIVE_DIRECTORY_USER
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ACTIVE_DIRECTORY_USER_ID", TypeName = "int")]
        public int ACTIVE_DIRECTORY_USER_ID { get; set; }
        public string DNI { get; set; }
        public string Display_Name { get; set; }
        public string Email_Address { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public decimal USER_TYPE_ID { get; set; }

        [ForeignKey("USER_TYPE_ID")]
        public virtual IT_USER_TYPE IT_USER_TYPE { get; set; }
    }
}
