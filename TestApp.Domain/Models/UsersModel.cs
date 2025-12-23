using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain.Models
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: UsersModel
    /// </summary
    public class UsersModel
    {

        [Required(ErrorMessage = "Usuario es requerido")]
        public string User { get; set; } = null!;

        [Required(ErrorMessage = "Password es requerido")]
        public string Password { get; set; } = null!;
        public string? Email { get; set; }

    }
}
