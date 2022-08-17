// See https://aka.ms/new-console-template for more information

//retorna um Tuple que basicamente é um objeto de retorno com vários membros de diferentes tipos, os valores de retorno podem ter alias ou não
(int age, string name) GetAgeAndName()
{	
	return (23, "Randerson Mendes");
}

(int, string) GetAgeAndNameWithoutAlias()
{
	return (23, "Randerson Mendes");
}

//para separar os valores de retorno do tuple basta acessa-los como num objeto qualquer
int age = GetAgeAndName().age;
string name = GetAgeAndName().name;

//se o metodo for setado para um variavel geral, essa variavel recebe o tipo do tuple, e pode acessar seus membros sem problemas
var teste = GetAgeAndName();

//nesse caso como não foram declarados nomes para os membros do Tuple, eles devem ser acessados pela propriedade generica Item
int age2 = GetAgeAndNameWithoutAlias().Item1;
string name2 = GetAgeAndNameWithoutAlias().Item2;

//printa todos os valores de retorno
Console.WriteLine(GetAgeAndName());

Console.WriteLine(age);
Console.WriteLine(name);

Console.WriteLine(age2);
Console.WriteLine(name2);
