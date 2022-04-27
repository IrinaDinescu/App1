using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Tables
{
    class FavoriteBookTable
    {
        private int registartionId;
        private string username;
        private int bookId;

        [PrimaryKey, AutoIncrement]
        public int RegistrationId { get => registartionId; set => registartionId = value; }
        
        public int BookId { get => bookId; set => bookId = value; }
        public string Username { get => username; set => username = value; }
    }
}
