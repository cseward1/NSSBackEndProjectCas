﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Models.BookViewModels
{
    public class TrackedBooksViewModel
    {
        public ICollection<Book> BookShelf { get; set; }
    }
}
