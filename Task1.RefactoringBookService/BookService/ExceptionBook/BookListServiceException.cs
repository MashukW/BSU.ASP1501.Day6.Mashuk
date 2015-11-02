﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.ExceptionBook
{
    public class BookListServiceException : Exception
    {
        public BookListServiceException(string message) : base(message) { }

        public BookListServiceException(string message, Exception ex) : base(message, ex) { }
    }
}
