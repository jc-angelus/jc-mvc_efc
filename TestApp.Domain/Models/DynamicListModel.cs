using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestApp.Domain.Models
{
    /// <summary>
    /// Developer: Johans Cuéllar
    /// Date: 02/02/2025
    /// </summary>
    /// 
    public class DynamicListModel
    {
        public int Id { get; set; }
        public IEnumerable<SelectListItem> List { get; set; } = null!;

    }
}