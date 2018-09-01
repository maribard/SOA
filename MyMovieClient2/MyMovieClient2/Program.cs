using MyMovieClient2.ServiceReference1;
using MyMovieClient2.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//pyt1: jak się tworzą ID?
namespace MyMovieClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Service1Client movieClient = new Service1Client();
            Service2Client peopleClient = new Service2Client();

            var movies = movieClient.GetAll();
            if (!movies.Any())
            {
                
                var m1 = new Movie() { ReleaseYear = 2015, Title = "Titanic" };
                var m2 = new Movie() { ReleaseYear = 2012, Title = "Avatar" };
                var m3 = new Movie() { ReleaseYear = 2011, Title = "Wlaaad" };
                movieClient.Create(m1);
                movieClient.Create(m2);
                m3.Id = movieClient.Create(m3); // jezeli chcemy znac id

            }

            Console.WriteLine("Podaj imię:");
            string imie = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko:");
            string nazwisko = Console.ReadLine();

            var a1 = peopleClient.GetByName(imie, nazwisko);

            while (true)
            {
                movies = movieClient.GetAll();

                Console.WriteLine();
                Console.WriteLine("Wybierz opcje:");
                Console.WriteLine("a) Dodanie recenzji");
                Console.WriteLine("b) edycja recenzji");
                Console.WriteLine("c) usunięcie edycji");
                Console.WriteLine("d) zobacz recenzję dla filmów");
                Console.WriteLine("e) dodaj film");
                Console.WriteLine("q) Zakoncz gre");

                var k = Console.ReadKey();
                Console.WriteLine();
                switch (k.KeyChar)
                {

                    case 'a':
                        foreach (Movie movie in movies)
                        {
                            Console.WriteLine("Id filmu: " + movie.Id +
                                "\nTytuł: " + movie.Title);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Wpisz numer filmu, który chcesz ocenić");
                        var numerFilmu = Int32.Parse(Console.ReadLine().ToString());
                        Console.WriteLine("Wpisz recenzję:");
                        string s = Console.ReadLine();
                        Console.WriteLine("Wpisz ocenę filmu w skali 0 - 100:");
                        int ocena = Int32.Parse(Console.ReadLine().ToString());

                        var author = peopleClient.GetById(a1.Id);
                        var r = new Review() { Content = s, Score = ocena, MovieId = numerFilmu, Author = author };
                        peopleClient.CreateReview(r);

                        //Console.ReadLine();
                        break;

                    case 'b':
                        movies = movieClient.GetAll();
                        Console.WriteLine("Twoje recenzje:");
                        foreach (Review reviews in peopleClient.GetReviewsByAuthor(a1.Id))
                        {
                            var film = movieClient.GetById(reviews.MovieId);
                            Console.WriteLine("Tytuł filmu: " + film.Title +
                                "\nId recenzji: " + reviews.Id +
                                "\nRecenzja: " + reviews.Content + "\n");
                        }
                        Console.WriteLine("Wybierz id recenzji do edycji.");
                        var numerRecenzji = Int32.Parse(Console.ReadLine().ToString());
                        Console.WriteLine("Wpisz recenzję:");
                        s = Console.ReadLine();
                        Console.WriteLine("Wpisz ocenę filmu w skali 0 - 100:");
                        ocena = Int32.Parse(Console.ReadLine().ToString());

                        var film1 = peopleClient.GetReviewById(numerRecenzji);

                        author = peopleClient.GetById(a1.Id);
                        r = new Review() { Id = numerRecenzji, Content = s, Score = ocena, MovieId = film1.Id, Author = author };
                        peopleClient.UpdateReview(r);

                        break;

                    case 'c':
                        movies = movieClient.GetAll();
                        Console.WriteLine("Twoje recenzje:");
                        foreach (Review reviews in peopleClient.GetReviewsByAuthor(a1.Id))
                        {
                            var film = movieClient.GetById(reviews.MovieId);
                            Console.WriteLine("Tytuł filmu: " + film.Title +
                                "\nId recenzji: " + reviews.Id +
                                "\nRecenzja: " + reviews.Content + "\n");
                        }
                        Console.WriteLine("Wybierz id recenzji do usunięcia:");
                        numerRecenzji = Int32.Parse(Console.ReadLine().ToString());
                        peopleClient.DeleteReview(numerRecenzji);
                        break;

                    case 'd':
                        foreach (Movie movie in movies)
                        {
                            Console.WriteLine("Id filmu: " + movie.Id +
                                "\nTytuł: " + movie.Title);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Dla którego filmu chcesz zobaczyć recenzję?");
                        numerFilmu = Int32.Parse(Console.ReadLine().ToString());
                        var listaRecenzjiDlaFilmu = peopleClient.GetReviewsByMovie(numerFilmu);

                        //var listaRecenzjiDlaAutora = peopleClient.GetReviewsByAuthor(a1.Id);

                        var wynik = listaRecenzjiDlaFilmu; //.Intersect(listaRecenzjiDlaAutora);
                        //zapytać Kamila o recenzję dla filmu jednego autora

                        int suma = 0;
                        int licznik = 0;
                        foreach (Review reviev in listaRecenzjiDlaFilmu)
                        {
                            suma = suma + reviev.Score;
                            licznik++;
                        }
                        Console.WriteLine("Średnia ocen dla filmu: " + suma / licznik);
                        Console.WriteLine("\nWszystkie recenzje:");
                        foreach (Review reviev in listaRecenzjiDlaFilmu)
                        {
                            Console.WriteLine("Id recenzji: " + reviev.Id +
                                "\nRecenzja: " + reviev.Content + " Autor: " + reviev.Author.Name);
                        }
                        Console.WriteLine();
                        break;

                    case 'e':
                        Console.WriteLine();
                        Console.WriteLine("Podaj tytuł filmu:");
                        var tytuł = Console.ReadLine();
                        Console.WriteLine("Rok wydania:");
                        var rok = Int32.Parse(Console.ReadLine().ToString());
                        var m5 = new Movie() { ReleaseYear = rok, Title = tytuł };
                        movieClient.Create(m5);
                        break;

                    case 'q':
                        Console.WriteLine("Koniec");
                        return;
                        break;
                }
            }

            // przykład tworzenia recenzji
            // var author = peopleClient.GetById(2);
            // var r = new Review() { Content= "Ala ma kota", Score = 65, MovieId = m3.Id, Author = author };
            // peopleClient.CreateReview(r);

        }
    }
}
