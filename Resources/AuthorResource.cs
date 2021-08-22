using System.ComponentModel;

namespace LibraryAPI.Resources
{
    public class AuthorResource
    {
        public long AuthorId { get; set; }
        [DisplayName("First Name")]   
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public string FullName { get; set; }
            
        
    }  
            
    
}
