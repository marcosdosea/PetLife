using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly PetLifeContext context;

        public ProdutoService(PetLifeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria um novo produto na base de dados
        /// </summary>
        /// <param name="produto">dados do produto</param>
        /// <returns>id do novo produto</returns>
        public uint Create(Produto produto)
        {
            context.Add(produto);
            context.SaveChanges();
            return (uint)produto.Id;
        }

        /// <summary>
        /// Remover dados de um produto da base de dados
        /// </summary>
        /// <param name="id">id do produto</param>
        public void Delete(uint id)
        {
            var produto = context.Produtos.Find(id);
            if (produto != null)
            {
                context.Remove(produto);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Atualizar dados de um produto da base de dados
        /// </summary>
        /// <param name="produto">novos dados do produto</param>
        public void Edit(Produto produto)
        {
            context.Update(produto);
            context.SaveChanges();
        }

        /// <summary>
        /// Obter os dados de um produto da base de dados
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns>dados do produto</returns>
        public Produto Get(uint id)
        {
            return context.Produtos.Find(id);
        }

        /// <summary>
        /// Obter dados de todos os produtos da base de dados
        /// </summary>
        /// <returns>dados dos produtos</returns>
        public IEnumerable<Produto> GetAll()
        {
            var query = from produto in context.Produtos
                        orderby produto.Id
                        select new Produto
                        {
                            Id = produto.Id,
                            Nome = produto.Nome,
                            Codigo = produto.Codigo,
                            Ativo = produto.Ativo,
                            Quantidade = produto.Quantidade,
                            Descricao = produto.Descricao,
                            Preco = produto.Preco,
                            IdPetshop = produto.IdPetshop
                        };
            return query;
        }

        /// <summary>
        /// Obter dados dos produtos ordenado pelo nome que iniciam com um nome
        /// </summary>
        /// <param name="nome">nome a ser buscado</param>
        /// <returns>lista de produtos</returns>
        public IEnumerable<Produto> GetByNome(string nome)
        {
            var query = from produto in context.Produtos
                        where produto.Nome.StartsWith(nome)
                        orderby produto.Nome
                        select new Produto
                        {
                            Id = produto.Id,
                            Nome = produto.Nome,
                            Codigo = produto.Codigo,
                            Ativo = produto.Ativo,
                            Quantidade = produto.Quantidade,
                            Descricao = produto.Descricao,
                            Preco = produto.Preco,
                            IdPetshop = produto.IdPetshop
                        };
            return query;
        }
    }
}
