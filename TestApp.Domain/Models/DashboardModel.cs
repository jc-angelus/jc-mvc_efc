using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain.Models
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 02/02/2025
    /// Class: DashboardModel
    /// </summary
    public class DashboardModel
    {        

        [Range(1, int.MaxValue, ErrorMessage = "El campo cedula es requerido")]
        [DisplayName("Document Id")]
        public int DocumentID { get; set; }
        public string LastName { get; set; } = null!;
        public string Name { get; set; } = null!;

        [DisplayName("Genders")]
        public int GendersId { get; set; }
        public DynamicListModel SelectListGenders { get; set; } = null!;

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Marital Status")]
        public int MaritalStatusId { get; set; }
        public DynamicListModel SelectListMaritalStatus { get; set; } = null!;
        public List<ClientsModel> ClientsList { get; set; } = null!;

    }
}
