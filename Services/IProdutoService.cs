using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Services;

public class IProdutoService
{
    Task<List<Produto>> ListarTodosAsync();
    Task<Produto?> BuscarPorIdAsync(int id);
    Task<Produto> CriarAsync(Produto produto);
    Task<Produto?> AtualizarAsync(int id, Produto produto);
    Task<bool> RemoverAsync(int id);
}