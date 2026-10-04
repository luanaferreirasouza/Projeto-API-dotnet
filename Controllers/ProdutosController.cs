using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;
namespace MinhaPrimeiraApi.Controllers;

[ApiController]

[Route("api/[controller]")]

public class ProdutosController : ControllerBase
{
   private static readonly List<Produto> Produtos = new List<Produto>
   {
        new Produto { Id = 1, Nome = "Caderno", Preco = 10.99m },
        new Produto { Id = 2, Nome = "Lápis", Preco = 1.49m},
        new Produto {Id = 3, Nome = "Borracha", Preco = 2.00m},
        new Produto {Id = 4, Nome = "Caneta", Preco = 3.50m},
        new Produto {Id = 5, Nome = "Mochia", Preco = 4.00m},
        new Produto {Id =6, Nome = "Estojo", Preco = 15.00m},
        new Produto {Id = 7, Nome = "Apontado", Preco = 1.99m},
        new Produto {Id = 8, Nome = "Régua", Preco = 2.50m},
        new Produto {Id = 9, Nome = "Tesoura", Preco = 8.90m},
        new Produto {Id = 10, Nome = "Cola", Preco = 4.00m},
   };
    [HttpGet]

    public IActionResult ListarTodos()
    {
        return Ok(Produtos);
    }
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        if (id<=0)
        {
            return BadRequest("O ID deve ser maior que zero.");
        }

        var produto = Produtos.FirstOrDefault (p => p.Id == id);

        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        return Ok(produto);
    }
    [HttpPost]

    public IActionResult Criar([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok($"Produto '{produto.Nome}' criado com sucesso!");
    }
}

