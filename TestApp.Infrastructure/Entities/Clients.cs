using TestApp.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Infrastructure.Entities
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: Clients
    /// </summary

    [Table("Clients")]
    public class Clients
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string LastName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }        
        public int MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; } = null!;
        public int GendersId { get; set; }
        public virtual Genders Genders { get; set; } = null!;
    }
}