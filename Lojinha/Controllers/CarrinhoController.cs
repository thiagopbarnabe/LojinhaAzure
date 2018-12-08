using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Lojinha.Core.Services;
using Lojinha.Core.Models;

namespace Lojinha.Controllers
{
    [Authorize]
    public class CarrinhoController:Controller
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly IProdutoServices _produtoServices;
        public CarrinhoController(IProdutoServices produtoServices, ICarrinhoService carrinhoService)
        {
            _produtoServices = produtoServices;
            _carrinhoService = carrinhoService;
        }


        public async Task<IActionResult> Add(string id)
        {
            var usuario = HttpContext.User.Identity.Name;

            Carrinho carrinho = _carrinhoService.Obter(usuario);

            carrinho.Add(await _produtoServices.ObterProduto(id));

            _carrinhoService.Salvar(usuario, carrinho);

            return PartialView("Index", carrinho);
        }

        public async Task<IActionResult> Finalizar()
        {
            var usuario = HttpContext.User.Identity.Name;
            var carrinho = _carrinhoService.Obter(usuario);

            //TODO: Inserir Mensagem na Queue

            _carrinhoService.Limpar(usuario);

            return View(carrinho);
        }
    }
}
