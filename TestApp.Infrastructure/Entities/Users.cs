using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Infrastructure.Entities
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: User
    /// </summary
    /// 
    [Table("Users")]
    public class Users: Audit {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        public string LastName { get; set; } = null!;

        [StringLength(250)]
        public string Name { get; set; } = null!;       
        
        [StringLength(250)]
        public string Email { get; set; } = null!;

        [StringLength(250)]
        public string UserName { get; set; } = null!;

        [StringLength(250)]
        public string Password { get; set; } = null!;                
        public bool State { get; set; }    
    }
}