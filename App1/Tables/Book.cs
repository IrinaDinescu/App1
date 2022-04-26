using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Tables
{
    public class Book
    {
        private int id;
        private string imageFilePath;
        private string author;
        private string description;
        private string name;
        private string genre;
        private float raiting;
        private int pageNo;

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }
        public string ImageFilePath { get => imageFilePath; set => imageFilePath = value; }
        public string Author { get => author; set => author = value; }
        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public float Raiting { get => raiting; set => raiting = value; }
        public int PageNo { get => pageNo; set => pageNo = value; }
    }
}
