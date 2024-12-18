using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trace_Api.Model
{
    public class User:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string? FullName { get; set; }
        [MaxLength(50)]
        public string? Phone { get; set; }
        [MaxLength(50)]
        public string? Role { get; set; }

        //新增
        [MaxLength(50)]
        public string? Message {  get; set; }
        [MaxLength]
        public byte[]? AvatarData { get; set; }
    }
}
