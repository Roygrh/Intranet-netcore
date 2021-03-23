using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class ContentVM
    {
        public decimal Id { get; set; }
        [Display(Name = "Nombre del contenido")]
        [Required(ErrorMessage ="El nombre del archivo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser de al menos {2} y maximo de {1} caracteres", MinimumLength =3)]
        public string Name { get; set; }
        [Display(Name = "Descripción del contenido")]
        [Required(ErrorMessage = "La descripción del archivo es obligatoria")]
        [StringLength(250, ErrorMessage = "El {0} debe ser de al menos {2} y maximo de {1} caracteres", MinimumLength = 3)]
        public string Description { get; set; }
        public decimal Id_Type_Content { get; set; }
        public string ID_Type_Content_Text { get; set; }
        [Display(Name = "Tipo de contenido")]
        public string Type_Content_Name { get; set; }
        //public List<ContentTypeVM> Content_Type_List { get; set; }
        [Display(Name = "Nombre del archivo")]
        public string File_Name { get; set; }
        [Display(Name = "Ubicación del archivo")]
        public string File_Location { get; set; }
        //public HttpPostedFileBase FILE { get; set; }
        public string ImageInBase64 { get; set; }
        public decimal ID_AREA_FUNCIONAL { get; set; }
        public string Creator_User { get; set; }
        public string Editor_User { get; set; }
        [Display(Name = "Fecha de publicación")]
        [DataType(DataType.Date)]
        public DateTime? Creation_Date { get; set; }
        public Nullable<DateTime> Edition_Date { get; set; }
        public DateTime Date { get; set; }
    }
}
