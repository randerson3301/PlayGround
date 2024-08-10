// See https://aka.ms/new-console-template for more information
using ObjectPoolingSample;
using ObjectPoolingSample.Models;

var pool = new ObjectPool<Person>(1);

var person = pool.GetObject();
person.Name = "Roberto";
person.Description = "A good person";
person.Address = "rua união";

var person2 = pool.GetObject();
person2.Name = "Julia";
person2.Description = "A nice person";
person2.Address = "Avenida 7 de julho";


Console.WriteLine("Pool count after pop: " + pool.Count);

pool.ReturnObject(person);
pool.ReturnObject(person2);


Console.WriteLine("Pool count after push: " + pool.Count);

var person3 = pool.GetObject();

Console.WriteLine("Person3: " + person3.Name);




