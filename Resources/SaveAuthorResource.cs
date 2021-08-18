using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Resources
{
    public class SaveAuthorResource
    {
        [Required(ErrorMessage = "Please add the author first name.")]
        [DisplayName("First Name")]   
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
            
        
    }  
            
    
}
