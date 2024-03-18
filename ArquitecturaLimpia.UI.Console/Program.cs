using ArquitecturaLimpia.Domain;
using ArquitecturaLimpia.Infrastructure.Services;

Categoria categoria = new Categoria() { 
    Nombre= "bebidas1",
    Descripcion = "Solo las bebidas",
};

Repository<Categoria> repoCateg = new();
//repoCateg.Add(categoria);
await repoCateg.Add(categoria);

    
//Console.WriteLine(repoCateg.GetById(1));

