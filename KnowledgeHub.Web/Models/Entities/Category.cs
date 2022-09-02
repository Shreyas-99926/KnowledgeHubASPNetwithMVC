using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Web.Models.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Kindly Enter CategoryName...")]
        [MaxLength(50)]
        public string Name { get; set; }    
        //Create a UI for CRUD Operation 
        //Create DAL Layer for CRUD Operation
        public string Description { get; set; }
    }
}
