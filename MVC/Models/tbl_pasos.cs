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
    
    public partial class tbl_pasos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_pasos()
        {
            this.tbl_reseta = new HashSet<tbl_reseta>();
        }
    
        public int idpas { get; set; }
        public string paso1 { get; set; }
        public Nullable<System.TimeSpan> timp1 { get; set; }
        public string paso2 { get; set; }
        public Nullable<System.TimeSpan> timp2 { get; set; }
        public string paso3 { get; set; }
        public Nullable<System.TimeSpan> timp3 { get; set; }
        public string paso4 { get; set; }
        public Nullable<System.TimeSpan> timp4 { get; set; }
        public string paso5 { get; set; }
        public Nullable<System.TimeSpan> timp5 { get; set; }
        public string paso6 { get; set; }
        public Nullable<System.TimeSpan> timp6 { get; set; }
        public string paso7 { get; set; }
        public Nullable<System.TimeSpan> timp7 { get; set; }
        public string comentario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_reseta> tbl_reseta { get; set; }
    }
}
