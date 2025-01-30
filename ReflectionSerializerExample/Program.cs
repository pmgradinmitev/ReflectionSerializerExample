// See https://aka.ms/new-console-template for more information
using ReflectionSerializerExample;

var person = new Person
{
    Name = "John",
    Age = 30,
    Address = new Address
    {
        Street = "123 Main St",
        City = "New York"
    }
};

var dictionary = ReflectionSerializer.Serialize(person);
var json = ReflectionSerializer.ConvertToJson(dictionary);
Console.WriteLine(json);