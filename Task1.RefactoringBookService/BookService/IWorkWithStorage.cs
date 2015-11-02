using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public interface IWorkWithStorage<Book>
    {
        void WriteListBooksInFile(List<Book> listBookForWrite);

        List<Book> ReadFromFileToListBooks();
    }
}
