using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class FunctionalAreaVM
    {
        public decimal AREA_FUNCIONAL_ID { get; set; }
        [Display(Name = "Area Funcional")]
        public string NOMBRE_AREA_FUNCIONAL { get; set; }
    }
}
