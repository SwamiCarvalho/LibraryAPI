using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Resources
{
    public class SaveGenreResource
    {
        [Required(ErrorMessage = "Please add a genre name.")]
        public string Name { get; set; }
    }
}
