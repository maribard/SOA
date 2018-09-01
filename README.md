Projekt składa się z dwóch podprojektów:
1) AuthorsWebApplication – serwis REST w WebAPI z dwoma kontrolerami z odpowiednimi
akcjami CRUD, które używają bazy danych PostgresSQL oraz Npgsql i Entity Framework.
Przykładowe wywołanie metod w Postmanie:
GET http://localhost:54757/api/Book
POST http://localhost:54757/api/Book
PUT http://localhost:54757/api/Book
DELETE http://localhost:54757/api/Book/1
Do projektu jest dodana biblioteka LibraryYTDO.

2) Dwa serwisy WCF z akcjami CRUD. Prawie cała logika znajduje się w dwóch bibliotekach
repozytoriów, które są oparte o bibliotekę dla modeli i bazę NoSQL – LiteDB.
Przetestować aplikację można przy pomocy aplikacji konsolowej MyMovieClient2 – oddzielna
solucja.
