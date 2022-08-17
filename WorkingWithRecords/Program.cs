// See https://aka.ms/new-console-template for more information
var book = new Book("1984", "George Orwell", new DateOnly(1952, 05, 15));
var book2 = new Book("1984", "George Orwell", new DateOnly(1952, 05, 15));

//para desconstruir um record, basta declarar variaveis na mesma ordem do construtor
var (title, author, releaseDate) = book;
     
Console.WriteLine(book);

//a comparação é feita pelas propriedades que no caso possuem os mesmos valores, portanto o retorno é TRUE
//porém isso não quer dizer que os records possuem a mesma referencia
Console.WriteLine(book == book2);

Console.WriteLine(title);
Console.WriteLine(author);
Console.WriteLine(releaseDate);

