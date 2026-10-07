using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Repositories;
public class ProdutoRepository : IProdutorRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ListarTodosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto?> BuscarPorIdAsync(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<Produto> CriarAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto?> AtualizarAsync(int id, Produto produtoAtualizado)
    {
        var produtoExistente = await _context.Produtos.FindAsync(id);
        if (produtoExistente == null)
        {
            return null;
        }

        produtoExistente.Nome = produtoAtualizado.Nome;
        produtoExistente.Preco = produtoAtualizado.Preco;

        await _context.SaveChangesAsync();
        return produtoExistente;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var produtoExistente = await _context.Produtos.FindAsync(id);
        if (produtoExistente == null)
        {
            return false;
        }

        _context.Produtos.Remove(produtoExistente);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExisteNomeAsync(string nome)
    {
        return await _context.Produtos.AnyAsync(p => p.Nome == nome);
    }
}