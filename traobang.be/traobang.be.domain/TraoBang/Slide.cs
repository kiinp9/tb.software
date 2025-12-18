using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thongbao.be.shared.Interfaces;
using traobang.be.shared.Constants.Db;
using traobang.be.shared.Constants.TraoBang;

namespace traobang.be.domain.TraoBang
{
    [Table(nameof(Slide), Schema = DbSchemas.TraoBang)]
    [Index(
     nameof(Id),
     IsUnique = false,
     Name = $"IX_{nameof(Slide)}"
 )]
    public class Slide : ISoftDelted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdSubPlan { get; set; }
        /// <summary>
        /// <see cref="LoaiSlides"/>
        /// </summary>
        public int LoaiSlide { get; set; }
        public int IdSinhVienNhanBang { get; set; }
        public string? NoiDung { get; set; }
        public string? Note { get; set; }
        /// <summary>
        /// <see cref="TraoBangConstants"/>
        /// </summary>
        public int TrangThai { get; set; }
        public int Order { get; set; }
        public bool IsShow { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
        public string? DeletedBy { get; set; }
    }
}
