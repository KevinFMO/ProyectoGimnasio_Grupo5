using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Service
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Precio { get; set; }
    }
}
