using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Resources
{
    public class SaveGenreResource
    {
        [Required(ErrorMessage = "Please add a genre name.")]
        public string Name { get; set; }
    }
}
