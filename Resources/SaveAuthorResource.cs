using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
