using Lojinha.Core.Models;
using Lojinha.Infrastructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Controllers
{
    [Authorize]
    public class ProdutosController:Controller
    {
        private readonly IAzureStorage _azureStorage;
        public ProdutosController(IAzureStorage azureStorage)
        {
            _azureStorage = azureStorage;
        }
        public IActionResult Create()
        {
            var produto = new Produto
            {
                Id = 331850,
                Nome = "Xbox One X",
                Categoria = new Categoria
                {
                    Id = 1,
                    Nome = "Consoles"
                },
                Descricao = "Xbox One X Scorpio Edition",
                Fabricante= new Fabricante
                {
                    Id=1,
                    Nome="Microsoft"
                },
                Preco=2500m,
                Tags= new[] {"xbox", "console", "videogame", "microsoft"},
                ImagemPrincipalUrl = "https://www.windowscentral.com/sites/wpcentral.com/files/styles/xlarge_wm_blw/public/field/image/2017/08/xbox-one-x-scorpio-controller-2.jpg"

            };

            _azureStorage.AddProduto(produto);


            return Content("Ok");
        }
    }
}
