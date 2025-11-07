using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriCholcaGiovanny.common.DTOs
{
    public class CategoriaDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [StringLength(20, ErrorMessage = "El ancho del campo es muy largo")]
        public string? Descripcion { get; set; }
    }
}
