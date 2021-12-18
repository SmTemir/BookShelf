using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.Data.Entities
{
    public class Book
    {
        public int ID { get; set; }

        /// <summary>
        /// Название книги
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Полное ФИО автора 
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Дата издания книги
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Отдана на руки
        /// </summary>
        public bool IsAbsent { get; set; }

        /// <summary>
        /// Дата добавления книги в систему
        /// </summary>
        public DateTime BeginDate { get; set; }

        public DateTime DeleteDate { get; set; }
    }
}
