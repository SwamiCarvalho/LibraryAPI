﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Author
    {
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<BooksAuthors> BooksAuthors { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}