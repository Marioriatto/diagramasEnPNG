// Open Closed cambiar add con otro if
abstract class Customer
{
    public abstract void Add(Database db);
}

class NewCustomer : Customer
{
    public override void Add(Database db) => db.Add();
}

class ExistingCustomer : Customer
{
    public override void Add(Database db) => db.AddExistingCustomer();
}
// isp, al agregar el read a una interfaz que ya existe, se van a tener que cambiar las clases que la implementan
interface ICustomer
{
    void Add();
}

interface ICustomerImproved : ICustomer
{
    void Read();
}

class OldCustomer : ICustomer           // sigue compilando sin cambios
{
    public void Add() { /* ... */ }
}

class NewCustomer : ICustomerImproved   // usa ambas
{
    public void Add() { /* ... */ }
    public void Read() { /* ... */ }
}
// single responsability el customer tiene mas de una responsabilidad
class FileLogger
{
    public void Handle(string error)
        => File.WriteAllText(@"C:\Error.txt", error);
}

class Customer
{
    private readonly FileLogger logger = new FileLogger();

    public void Add(Database db)
    {
        try { db.Add(); }
        catch (Exception ex) { logger.Handle(ex.ToString()); }
    }
}

// open closed createpost decide con if como guardar el c ontenido
abstract class Post
{
    public abstract void CreatePost(Database db, string postMessage);
}

class SimplePost : Post
{
    public override void CreatePost(Database db, string postMessage)
        => db.Add(postMessage);
}

class TagPost : Post
{
    public override void CreatePost(Database db, string postMessage)
        => db.AddAsTag(postMessage);
}
// lsp, equiry hereda de customer, pero su add tira excepcion. en el foreach de violatingliskovs
// cualquier customer deberia poder agragarse, y ahi enquiry rompe el programa
// la sublase no debe sustituir a la clase base
interface IDiscount
{
    int Discount(int sales);
}

interface IDatabaseable
{
    void Add(Database db);
}

interface ICustomer : IDiscount, IDatabaseable { }

class GoldCustomer : ICustomer
{
    public int Discount(int sales) => sales - 100;
    public void Add(Database db) => db.Add();
}

class SilverCustomer : ICustomer
{
    public int Discount(int sales) => sales - 50;
    public void Add(Database db) => db.Add();
}

class Enquiry : IDiscount               // NO implementa IDatabaseable
{
    public int Discount(int sales) => sales * 5;
}
// dip, customer crea un new filelogger, queda acoplada a una implementacion concreta y es dificil de probar
// o cambiar a otro log
interface ILogger
{
    void Handle(string error);
}

class FileLogger : ILogger
{
    public void Handle(string error)
        => File.WriteAllText(@"C:\Error.txt", error);
}

class DbLogger : ILogger
{
    public void Handle(string error) { /* guardar en BD */ }
}

class Customer
{
    private readonly ILogger logger;

    public Customer(ILogger logger)     // inyección por constructor
    {
        this.logger = logger;
    }

    public void Add(Database db)
    {
        try { db.Add(); }
        catch (Exception error) { logger.Handle(error.ToString()); }
    }
}
//lsp, ,electric duck agrega una precondicion que duc no tiene
// el que llamo a makeDuckSwim(IDuck) espera que el pato nade, pero con un electricDuck apagado no pasa nada
public class ElectricDuck : IDuck
{
    public void Swim()
    {
        if (!IsTurnedOn)
            TurnOnDuck(); // se llama desde aca :v
    }
}
