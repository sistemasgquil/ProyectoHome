//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Listas0.Areas.AreaProyectos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agendar
    {
        public int empresa { get; set; }
        public int sucursal { get; set; }
        public long codigo { get; set; }
        public long id_dr { get; set; }
        public long id_person { get; set; }
        public System.DateTime fecha_desde { get; set; }
        public System.DateTime fecha_hasta { get; set; }
        public System.TimeSpan hora_inicio { get; set; }
        public System.TimeSpan hora_fin { get; set; }
        public string observacion { get; set; }
    
        public virtual sucrusal sucrusal { get; set; }
    }
}
