using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Domain
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
    }
}
