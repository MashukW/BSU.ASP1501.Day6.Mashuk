using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BookService.ExceptionBook;

namespace BookService
{
    public class BookListService
    {
        public List<Book> ListBooks { get; private set; }

        private IWorkWithStorage<Book> saveAndLoad;

        public BookListService(IWorkWithStorage<Book> saveAndLoad)
        {
            if (saveAndLoad == null)
                throw new ArgumentNullException("Class SaveAndLoad File is null");

            this.saveAndLoad = saveAndLoad;

            try
            {
                ListBooks = saveAndLoad.ReadFromFileToListBooks();
            }
            catch (Exception ex)
            {
                throw new BookListServiceException("Unable to download data from file", ex);
            }
        }

        #region Public Methods (AddBook, RemoveBook, FindByTag, SortsBooksByTag)

        public void AddBook(Book book)
        {
            if (book == null)
                return;
            if (ListBooks.Contains(book))
                throw new AddBookException("This book already exists in the list");

            ListBooks.Add(book);
        }

        public void AddBook(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentException("Books collection is null");

            foreach (Book book in books)
                AddBook(book);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
                return;
            if (!ListBooks.Contains(book))
                throw new RemoveBookException("Book to be deleted was not found");

            ListBooks.Remove(book);
        }

        public List<Book> FindByTag(Predicate<Book> tag)
        {
            return ListBooks.FindAll(tag);
        }

        public void SortsBooksByTag()
        {
            if (ListBooks.Count == 0)
                return;

            ListBooks.Sort();
        }

        public void SortsBooksByTag(Func<Book, object> keySelector)
        {
            ListBooks = ListBooks.OrderBy(keySelector).ToList();
        }

        public void SaveFromListBookToFile() => saveAndLoad.WriteListBooksInFile(ListBooks);

        public List<Book> LoadFromFileToListBook() => saveAndLoad.ReadFromFileToListBooks();

        #endregion
    }
}
