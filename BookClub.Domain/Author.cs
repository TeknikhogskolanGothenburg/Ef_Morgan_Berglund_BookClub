using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }


    }
}
