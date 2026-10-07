using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Repositories;

namespace MinhaPrimeiraApi.Services;
public class ProdutoService : IProdutoService
{
    private readonly IProdutorRepository _repository;

    public ProdutoService(IProdutorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Produto>> ListarTodosAsync()
    {
        return await _repository.ListarTodosAsync();
    }

    public async Task<Produto?> BuscarPorIdAsync(int id)
    {
        return await _repository.BuscarPorIdAsync(id);
    }

    public async Task<Produto> CriarAsync(Produto produto)
    {
        if (produto.Preco < 0.10m)
        {
            throw new ArgumentException("O preço do produto deve ser maior ou igual a 0,10.");
        }

        if (await_repository.ExisteNomeAsync(produto.Nome))
        {
            throw new ArgumentException($"Já existe um produto com o nome '{produto.Nome}'.");
        }
        return await _repository.CriarAsync(produto);
    }

    public async Task<Produto?> AtualizarAsync(int id, Produto produto)
    {
        return await _repository.AtualizarAsync(id, produto);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        return await _repository.RemoverAsync(id);
    }
}