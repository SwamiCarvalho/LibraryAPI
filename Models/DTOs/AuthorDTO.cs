using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    public class AuthorDTO
    {
        public long Id { get; set; }
        [DisplayName("First Name")]   
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        public string FullName
        { get
            {
                return FirstName + " " + LastName; 
            } 
        }
            
        
    }  
            
    
}
