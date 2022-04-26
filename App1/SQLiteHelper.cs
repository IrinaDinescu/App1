using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App1.Tables;
using SQLite;

namespace App1
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Book>();
        }

        public Task<int> CreateBook(Book book)
        {
            return db.InsertAsync(book);

        }

        public Task<List<Book>> ReadBooks()
        {
            return db.Table<Book>().ToListAsync();
        }

        public Task<int> UpdateBook(Book book)
        {
            return db.UpdateAsync(book);
        }

        public Task<List<Book>> getBookById(int id)
        {
            return db.Table<Book>().Where(b => b.Id.Equals(id)).ToListAsync();
        }

        public Task<int> DeleteBook(Book book)
        {
            return db.DeleteAsync(book);
        }
    }
}
