using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class AuthorizationMovementVM
    {
        public decimal MOVIMIENTO_ID { get; set; }
        public decimal ID_AUTORIZACION { get; set; }
        public decimal ID_ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string MOTIVO { get; set; }
        public decimal ID_AREA_FUNCIONAL { get; set; }
        public string ID_USUARIO_AUTORIZA { get; set; }
        public decimal ID_TIPO_USUARIO { get; set; }
        public AuthorizationStateVM ESTADO { get; set; }
    }
}
