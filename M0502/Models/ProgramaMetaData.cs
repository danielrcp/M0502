using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M0502.Models
{
    public partial class sm_Programa
    {
        [MetadataType(typeof(ProgramaMetaData))]
        class ProgramaMetaData
        {
            [Display(Name ="Nombre del programa:")]
            public object descripcion { get; set; }
            [Display(Name = "Estado del programa:")]
            public object idEstado { get; set; }
        }
    }
}