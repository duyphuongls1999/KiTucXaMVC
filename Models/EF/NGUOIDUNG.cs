namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }

        [Key]
        [StringLength(15)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTenNV { get; set; }

        public int? ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
