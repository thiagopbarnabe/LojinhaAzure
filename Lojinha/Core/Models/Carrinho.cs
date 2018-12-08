using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Core.Models
{
    public class Carrinho
    {
        public List<CarrinhoItem> Items { get; set; }

        public Carrinho()
        {
            Items = new List<CarrinhoItem>();
        }

        public void Add(Produto produto)
        {
            if(Items.Any(x=>x.Produto.Id==produto.Id))
            {
                var item = Items.FirstOrDefault(x => x.Produto.Id == produto.Id);
                item.Quantidate++;
            }
            else
            {
                Items.Add(new CarrinhoItem
                {
                    Produto = produto,
                    Quantidate=1
                });
            }
        }
    }


}
