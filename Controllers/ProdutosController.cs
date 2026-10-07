using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;
namespace MinhaPrimeiraApi.Controllers;
using MinhaPrimeiraApi.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]

[Route("api/[controller]")]

public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]

    public async Task<IActionResult> ListarTodos()
    {
        var produtos = await _context.Produtos.ToListAsync();
        return Ok(produtos);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        if (id<=0)
        {
            return BadRequest("O ID deve ser maior que zero.");
        }

        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        return Ok(produto);
    }
    
    [HttpPost]

    public async Task<IActionResult> Criar([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return Ok($"Produto '{produto.Nome}' criado com sucesso!");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produtoAtualizado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;

        await _context.SaveChangesAsync();
        return Ok($"Produto com ID {id} atualizado com sucesso!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar (int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return Ok($"Produto com ID {id} deletado com sucesso!");
    }
}