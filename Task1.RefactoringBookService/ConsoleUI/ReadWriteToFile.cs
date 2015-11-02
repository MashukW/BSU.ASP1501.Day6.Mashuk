using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BookService;

namespace ConsoleUI
{
    public class SaveAndLoadFile : IWorkWithStorage<Book>
    {
        private readonly string path;

        public SaveAndLoadFile(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path is null");
            this.path = path;
        }
        
        public void WriteListBooksInFile(List<Book> listBookForWrite)
        {
            if (listBookForWrite == null)
                throw new ArgumentException("Collection books is null");

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                for (int i = 0; i < listBookForWrite.Count; i++)
                {
                    writer.Write(listBookForWrite[i].Author);
                    writer.Write(listBookForWrite[i].Title);
                    writer.Write(listBookForWrite[i].NumberOfPages);
                    writer.Write(listBookForWrite[i].Publisher);
                    writer.Write(listBookForWrite[i].YearIssued);
                }
            }
        }

        public List<Book> ReadFromFileToListBooks()
        {
            List<Book> listBookForRead = new List<Book>();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (reader.PeekChar() > -1)
                {
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    int numberOfPages = reader.ReadInt32();
                    string publisher = reader.ReadString();
                    int yearIssued = reader.ReadInt32();

                    listBookForRead.Add(new Book(author, title, numberOfPages, publisher, yearIssued));
                }
            }
            return listBookForRead;
        }
    }
}
