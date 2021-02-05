using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MantClientes.Models.Validation
{

     [MetadataType(typeof(EmployeeMetadata))]
     public partial class Cliente
     {

     }

    public class EmployeeMetadata
        {
         [Required(AllowEmptyStrings = false, ErrorMessage = "Debe completar el nombre")]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe completar el telefono")]
        public string Telefono { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe completar la direccion")]
        public string Direccion { get; set; }
    }

}