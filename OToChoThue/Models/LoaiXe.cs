﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OToChoThue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class LoaiXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiXe()
        {
            this.DonThueXes = new HashSet<DonThueXe>();
        }

        [DisplayName("ID của xe")]
        public string XeID { get; set; }
        [DisplayName("Tên xe")]
        public string TenXe { get; set; }
        [DisplayName("Biển số")]
        public string BienSo { get; set; }
        [DisplayName("Gía thuê")]
        public Nullable<decimal> GiaThue { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonThueXe> DonThueXes { get; set; }
    }
}
