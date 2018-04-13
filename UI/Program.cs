using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BookClub.Data;
using BookClub.Domain;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {

            ////Create
            //AddBook();
            //AddAuthor();
            //AddPublisher();
            //AddBookNotRaw();
            //AddMember();
            //AddCategory();
            //AddReservedBook();

            ////Read
            //FindMember("Morgan", "Berglund");
            //FindBookByTitleAsync("Djunglebook");
            //FindBookByAuthorRaw("Lewis");
            //FindBookByCategory();

            ////Update

            ////Delete

        }
        //Borde undevika * i select men det är bara ett exempel.
        private static void FindBookByAuthorRaw(string name)
        {
            var context = new BookClubContext();
            var author = context.Authors
                                .FromSql("SELECT Authors.Id, FirstName, LastName, BirthDate, Nationality FROM dbo.Authors " +
                                "WHERE Authors.FirstName LIKE '" + @name + "%'")
                                .ToList();

            foreach (var a in author)
            {
                Console.WriteLine("Author: {0} {1} Born {2}", a.FirstName, a.LastName, a.Nationality, a.BirthDate);
            }

        }

        //Det är oftare man använder att leta i databasen än skriva därför Async då kan man 
        //Blokera ui och troligen skicka upp ett meddelande om att den letar i databasen.
        private async static void FindBookByTitleAsync(string title)
        {
            var context = new BookClubContext();
            var book = await context.Books.FirstOrDefaultAsync(a => a.Title.StartsWith(title));
            Console.WriteLine("Bokinformation: {0} ISBN {1}   ", book.Title, book.ISBN);
        }

        private static void FindMember(string firstName, string lastName)
        {
            var context = new BookClubContext();
            try
            {
                var member = context.Members.FirstOrDefault(a => a.FirstName.StartsWith(firstName) && a.LastName.StartsWith(lastName));
                Console.WriteLine("Member found name: {0} {1} \n Birthdate: {2} \n member since: {3} ", member.FirstName, member.LastName, member.BirthDate, member.RegistrationDate);

            }
            catch (NullReferenceException)
            {

                Console.WriteLine("Member not found.");
            }

        }

        private static void AddReservedBook()
        {
            var context = new BookClubContext();
            string firstName = "Morgan";
            string lastName = "Berglund";
            string bookTitle = "Djunglebook";


            var member = context.Members.FirstOrDefault(a => a.FirstName.StartsWith(firstName) && a.LastName.StartsWith(lastName));
            var book = context.Books.FirstOrDefault(b => b.Title.StartsWith(bookTitle));
            if (member.FirstName != null && book.Title != null)
            {
                var borroweBook = new BorrowedBook { MemberId = member.Id, BookId = book.Id };
                context.Add(borroweBook);
                context.SaveChanges();
                Console.WriteLine("Member {0} {1} loaned the book {2}", member.FirstName, member.LastName, book.Title);
            }
            else
            {
                Console.WriteLine("Book or member not found.");
            }

        }



        private static void AddCategory()
        {
            var context = new BookClubContext();
            var category = new BookCategory { Name = "Fiction" };
            context.Add(category);
            context.SaveChanges();
        }

        private static void AddPublisher()
        {
            var context = new BookClubContext();
            var publisher = new Publisher { CompanyName = "William Collins", PublishDate = new DateTime(2013) };
            context.Add(publisher);
            context.SaveChanges();
        }

        private static void AddAuthor()
        {
            var context = new BookClubContext();
            var author = new Author { FirstName = "Lewis", LastName = "Carol", BirthDate = new DateTime(1832, 01, 27), Nationality = "United Kingdom" };
            context.Add(author);
            context.SaveChanges();
        }

        private static void AddBookNotRaw()
        {
            var context = new BookClubContext();
            string title = "";
            long isbn = 0;
            int authorId = 0;
            int publisherId = 0;
            var book = new Book { Title = title, ISBN = isbn, AuthorId = authorId, PublisherId = publisherId };


        }

        private static void AddMember()
        {
            var context = new BookClubContext();
            string firstName = "";
            string lastName = "";
            string exit = "Continue";
            DateTime birthDate = new DateTime(0);
            while (exit != "exit" && exit != "EXIT")
            {
                Console.WriteLine("Please enter your firstname");
                firstName = Console.ReadLine();
                Console.WriteLine("Please enter your lastname");
                lastName = Console.ReadLine();
                Console.WriteLine("Please enter your Birthdate yyyy,mm,dd");
                birthDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Write exit to stop input of new Members");
                exit = Console.ReadLine();
                var member = new Member { FirstName = firstName, LastName = lastName, RegistrationDate = DateTime.Now, BirthDate = birthDate };
                context.Add(member);
                context.SaveChanges();
            }
        }
        //RawSQL 
        private static void AddBook()
        {
            var context = new BookClubContext();
            int authorId = 1;
            long isbn = 123123141214;
            string title = "Djunglebook";
            int publisherId = 1;
            context.Database.ExecuteSqlCommand($"INSERT INTO Books (AuthorId,ISBN,PublisherId,Title) VALUES({authorId},{isbn},{publisherId},{title})");



        }


    }
}
