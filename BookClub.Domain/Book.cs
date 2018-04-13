using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BookClub.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long ISBN { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }

    }
}
