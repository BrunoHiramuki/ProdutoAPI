using Microsoft.AspNetCore.Mvc;
using Treino1.Model;
using Treino1.Repositorios;

namespace Treino1.Controllers
{
    public class ProdutoController : ControllerBase
    {
        [HttpGet("GetProdutos")]
        public ActionResult<List<Produto>> Get()
        {
            List<Produto> produtos = ProdutosApi.ObterTodos();
            return Ok(produtos);
        }

        [HttpGet("GetProduto")]
        public ActionResult<Produto> Get([FromQuery] int id)
        {
            Produto produto = ProdutosApi.ObterPorId(id);
            return produto;
        }

        [HttpPost("AddProduto")]
        public ActionResult<Produto> Add([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto não pode ser nulo.");
            }

            ProdutosApi.Adicionar(produto);

            return Ok(produto);
        }

        [HttpPut("AtualizarProduto")]
        public ActionResult<Produto> Put([FromBody] Produto produto)
        {
            if (produto == null)
            {
                BadRequest("Preencha os dados do produto");
            }

            ProdutosApi.Atualizar(produto);
            return Ok(produto);
        }

        [HttpDelete("DeletarProduto")]
        public ActionResult Delete ([FromQuery] int id)
        {
            ProdutosApi.Remover(id);
            return Ok();
        }


    }
}
