using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Resources
{
    public class PublisherResource
    {
        public long PublisherId { get; set; }
        [Required(ErrorMessage = "Please add the publisher name.")] 
        public string Name { get; set; }
        public string? Location { get; set; }
            
        
    }  
            
    
}
