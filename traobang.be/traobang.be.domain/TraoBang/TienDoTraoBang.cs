using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thongbao.be.shared.Interfaces;
using traobang.be.shared.Constants.Db;
using traobang.be.shared.Constants.TraoBang;

namespace traobang.be.domain.TraoBang
{
    [Table(nameof(TienDoTraoBang), Schema = DbSchemas.TraoBang)]
    [Index(
      nameof(Id),
      IsUnique = false,
      Name = $"IX_{nameof(TienDoTraoBang)}"
    )]
    public class TienDoTraoBang : ISoftDelted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPlan { get; set; }
        public int IdSubPlan { get; set; }
        public int IdSlide { get; set; }
        public int IdSinhVienNhanBang { get; set; }
        public string HoVaTen { get; set; } = String.Empty;
        public string MaSoSinhVien { get; set; } = String.Empty;
        public int TrangThai { get; set; }
        public string? Note { get; set; }
        public int Order { get; set; }
        public bool IsShow { get; set; }
        public bool TrackingDangTrao { get; set; }
        /// <summary>
        /// <see cref="LoaiSlides"/>
        /// </summary>
        public int LoaiSlide { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
        public string? DeletedBy { get; set; }

    }
}
