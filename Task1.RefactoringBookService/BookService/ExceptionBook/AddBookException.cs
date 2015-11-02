using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.ExceptionBook
{
    public class AddBookException : BookListServiceException
    {
        public AddBookException(string message) : base(message) { }
    }
}
