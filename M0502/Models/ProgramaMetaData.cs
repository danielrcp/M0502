using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M0502.Models
{
    [MetadataType(typeof(ProgramaMetaData))]
    public partial class sm_Programa
    {
        class ProgramaMetaData
        {
            [Display(Name ="Nombre del programa:")]
            [Required(ErrorMessage = "El nombre del programa es requerido")]
            [DataType(DataType.MultilineText)]
            public object descripcion { get; set; }
            [Display(Name = "Estado del programa:")]
            public object idEstado { get; set; }
        }
    }
}