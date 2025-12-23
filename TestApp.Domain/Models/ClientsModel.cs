using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain.Models
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: ClientsModel
    /// </summary
    public class ClientsModel
    {
        public int Id { get; set; }

        [DisplayName("Document Id")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo cedula es requerido")]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Name { get; set; } = null!;        

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]        
        public DateTime BirthDate { get; set; }
        
        [DisplayName("Marital Status")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El campo estado civil es requerido")]
        public int MaritalStatusId { get; set; }        
        public DynamicListModel SelectListMaritalStatus { get; set; } = null!;

        [DisplayName("Gender")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El campo genero es requerido")]
        public int GendersId { get; set; }
        public DynamicListModel SelectListGenders { get; set; } = null!;
    }

}