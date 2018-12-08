using Lojinha.Core.Models;

namespace Lojinha.Infrastructure.Storage
{
    public interface IAzureStorage
    {
        void AddProduto(Produto produto);
    }
}