using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Resources
{
    public class SaveAuthorResource
    {
        [DisplayName("First Name")]   
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
            
        
    }  
            
    
}
