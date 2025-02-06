using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{
    public class PositionStatusType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Column("status_name")]
        public string StatusName { get; set; }

        public ICollection<Position>? Positions { get; set; }
    }

}