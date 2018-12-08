using AutoMapper;
using Lojinha.Core.Models;
using Lojinha.Core.Services;
using Lojinha.Core.ViewModels;
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
        readonly IProdutoServices _produtosService;
        private readonly IMapper _mapper;
        public ProdutosController(IProdutoServices produtosService, IMapper mapper)
        {
            _produtosService = produtosService;
            _mapper = mapper;
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
                Fabricante = new Fabricante
                {
                    Id = 1,
                    Nome = "Microsoft"
                },
                Preco = 2500m,
                Tags = new[] { "xbox", "console", "videogame", "microsoft" },
                ImagemPrincipalUrl = "https://www.windowscentral.com/sites/wpcentral.com/files/styles/xlarge_wm_blw/public/field/image/2017/08/xbox-one-x-scorpio-controller-2.jpg"

            };

            //_azureStorage.AddProduto(produto);


            return Content("Ok");
        }

        public async Task<IActionResult> List()
        {
            var produtos = await _produtosService.ObterProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(vm);
        }

        public async Task<IActionResult> Details(string id)
        {
            var produto = await _produtosService.ObterProduto(id);
            return Json(produto);

        }
    }
}
