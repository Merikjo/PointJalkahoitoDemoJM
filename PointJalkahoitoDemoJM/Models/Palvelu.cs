//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PointJalkahoitoDemoJM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Palvelu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Palvelu()
        {
            this.Asiakas = new HashSet<Asiakas>();
            this.Henkilokunta = new HashSet<Henkilokunta>();
            this.Hoitaja = new HashSet<Hoitaja>();
            this.Varaus1 = new HashSet<Varaus>();
        }
    
        public int Palvelu_id { get; set; }
        [Display(Name = "Palvelun Nimi")]
        public string Palvelun_Nimi { get; set; }
        [Display(Name = "Palvelun Kesto")]
        public string Palvelun_Kesto { get; set; }
        [Display(Name = "Palvelun Hinta")]
        public string Palvelun_Hinta { get; set; }
        public Nullable<int> Asiakas_id { get; set; }
        public Nullable<int> Hoitaja_id { get; set; }
        public Nullable<int> Toimipiste_id { get; set; }
        public Nullable<int> Varaus_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asiakas> Asiakas { get; set; }
        public virtual Asiakas Asiakas1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Henkilökunta")]
        public virtual ICollection<Henkilokunta> Henkilokunta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoitaja> Hoitaja { get; set; }
        public virtual Hoitaja Hoitaja1 { get; set; }
        public virtual Toimipiste Toimipiste { get; set; }
        public virtual Varaus Varaus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Varaus> Varaus1 { get; set; }
    }
}
