using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thongbao.be.shared.Interfaces;
using traobang.be.shared.Constants.Db;
using traobang.be.shared.Constants.TraoBang;

namespace traobang.be.domain.TraoBang
{
    [Table(nameof(Plan), Schema = DbSchemas.TraoBang)]
    [Index(
        nameof(Id),
        IsUnique = false,
        Name = $"IX_{nameof(Plan)}"
    )]
    public class Plan : ISoftDelted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ten { get; set; } = String.Empty;
        public string MoTa { get; set; } = String.Empty;
        /// <summary>
        /// <see cref="TrangThaiPlan"/>
        /// </summary>
        
        public int TrangThai { get; set; }
        /// <summary>
        /// Map với bảng giao diện
        /// </summary>
        public int? IdGiaoDien { get; set; }
        public GiaoDien? GiaoDien { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
        public string? DeletedBy { get; set; }
    }
}
