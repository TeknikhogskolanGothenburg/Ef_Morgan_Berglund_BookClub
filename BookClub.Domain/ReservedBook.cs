using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Domain
{
    public class ReservedBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
