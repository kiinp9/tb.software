using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using traobang.be.shared.Constants.Db;

namespace traobang.be.domain.TraoBang
{
    [Table(nameof(GiaoDien), Schema=DbSchemas.TraoBang)]
    [Index(
        nameof(Id),
        IsUnique = false,
        Name = $"IX_{nameof(GiaoDien)}"
    )]
    public class GiaoDien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string TenGiaoDien { get; set; }
        public required string NoiDung { get; set; } 
        public string? MoTa { get; set; }
        public List<Plan> Plans { get; set; } = new List<Plan>();
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
        public string? DeletedBy { get; set; }
    }
}
