//record é um tipo especial de classe onde o compilador foca em suas propriedades e não na referencia
//Quando record é printado o programa mostra  suas propriedades e não seu tipo como na class
//um record é facilmente descontruido
public record Book(string Title, string Author, DateOnly ReleaseDate);