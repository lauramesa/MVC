//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_inf_original
    {
        public int idoc { get; set; }
        public Nullable<int> serier { get; set; }
        public string fuente { get; set; }
        public string ubicacion { get; set; }
    
        public virtual tbl_reseta tbl_reseta { get; set; }
    }
}