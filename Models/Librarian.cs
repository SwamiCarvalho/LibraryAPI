using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Librarian
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
    }
}