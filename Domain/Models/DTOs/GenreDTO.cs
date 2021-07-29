using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Models.DTOs
{
    public class GenreDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
