using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookService;
using BookService.ExceptionBook;
using NLog;

namespace ConsoleUI
{
    public class UserInterface
    {
        private static readonly Logger serviceBookLogger = LogManager.GetCurrentClassLogger();

        public static void DisplayBook(IList<Book> listBook)
        {
            serviceBookLogger.Info("Start Method display the list of books on the console");
            if (listBook != null)
                foreach (Book book in listBook)
                    Console.WriteLine(book.ToString());

            Console.WriteLine(new string('*', 80));
            serviceBookLogger.Info("Finish method display the list of books on the console");
        }

        public static void Main(string[] args)
        {
            SaveAndLoadFile sl = new SaveAndLoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt"));
            BookListService service = new BookListService(sl);

            Book existingBook = new Book("Блок Александр", "Ее песни", 116, "Минск-Пресс", 2014);
            Book bookForRemove = new Book("Салтыков-Щедрин Михаил", "Дикий помещик", 365, "Добрая книга", 2003);

            try
            {
                serviceBookLogger.Info("Start of block processing TYR in which adding books");
                service.AddBook(existingBook);
                serviceBookLogger.Info("End of block processing TYR in which adding books");
            }
            catch (AddBookException ex)
            {
                Console.WriteLine(ex.Message);
                serviceBookLogger.Info(ex.Message);
                serviceBookLogger.Error(ex.StackTrace);
            }
            
            try
            {
                serviceBookLogger.Info("Start of block processing TYR in which remove book");
                service.RemoveBook(bookForRemove);
                serviceBookLogger.Info("End of block processing TYR in which remove book");
            }
            catch (RemoveBookException ex)
            {
                Console.WriteLine(ex.Message);
                serviceBookLogger.Info(ex.Message);
                serviceBookLogger.Error(ex.StackTrace);
            }
            
            service.SortsBooksByTag(book => book.Title);
            serviceBookLogger.Info("Sorting internal list books by Title");
            DisplayBook(service.ListBooks);

            List<Book> resultFind = service.FindByTag(book => book.NumberOfPages == 189);
            serviceBookLogger.Info("Find list book where number of page = 189");
            DisplayBook(resultFind);
                
            Console.ReadKey();
        }
    }
}
