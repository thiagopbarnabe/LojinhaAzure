using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Lojinha.Core.Models;
using Lojinha.Core.Entities;

namespace Lojinha.Infrastructure.Storage
{
    public class AzureStorage : IAzureStorage
    {
        private readonly CloudStorageAccount _account;
        private readonly CloudTableClient _tableClient;

        public AzureStorage(IConfiguration config)
        {
            _account = CloudStorageAccount.Parse(
                config.GetSection("Azure:Storage").Value);

            _tableClient = _account.CreateCloudTableClient();
        }

        public void AddProduto(Produto produto)
        {
            var json = JsonConvert.SerializeObject(produto);
            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            var entity = new ProdutoEntity("13net", produto.Id.ToString());
            TableOperation operation = TableOperation.Insert(entity);
            table.ExecuteAsync(operation);

        }

        public List<Produto> ObterProdutos()
        {
            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            TableOperation operation = TableOperation.Retrieve("13net");

        }
    }
}
