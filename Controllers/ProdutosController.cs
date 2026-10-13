using Microsoft.AspNetCore.Mvc;
using EstoqueApi.Models;

namespace EstoqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        // O Dictionary simula um banco de dados em memória.
        // A chave é o Id do produto e o valor é o objeto Produto.
        private static Dictionary<int, Produto> _produtos = new Dictionary<int, Produto>();

        // GET: api/Produtos
        [HttpGet]
        public IActionResult Get()
        {
            // TODO:
            // 1. Retorne todos os produtos que estão guardados no Dictionary.
            // Dica: use _produtos.Values e retorne uma resposta HTTP de sucesso.
            return Ok(_produtos.Values);
        }

        // GET: api/Produtos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // TODO:
            // 1. Verifique se o Dictionary contém a chave recebida em "id".
            // 2. Se não contiver, retorne NotFound("Produto não encontrado.").
            // 3. Se contiver, retorne o produto armazenado nessa chave.
            // Dica: use ContainsKey(id) para verificar e _produtos[id] para acessar.
            if (!_produtos.ContainsKey(id))
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(_produtos[id]);
        }

        // POST: api/Produtos/pereciveis
        [HttpPost("pereciveis")]
        public IActionResult PostPerecivel([FromBody] ProdutoPerecivel novoProduto)
        {
            // TODO:
            // 1. Defina um Id para o novo produto.
            //    Para esta atividade, você pode usar _produtos.Count + 1.
            // 2. Adicione o produto ao Dictionary usando o Id como chave.
            // 3. Retorne o produto cadastrado em uma resposta HTTP de sucesso.
            // Dica: o objeto recebido já é um ProdutoPerecivel e também é um Produto.
            int novoId = _produtos.Count + 1;
            novoProduto.Id = novoId;
            _produtos[novoId] = novoProduto;
            return Ok(novoProduto);

        }

        // POST: api/Produtos/eletronicos
        [HttpPost("eletronicos")]
        public IActionResult PostEletronico([FromBody] ProdutoEletronico novoProduto)
        {
            // TODO:
            // 1. Defina um Id para o novo produto.
            // 2. Adicione o produto ao Dictionary usando o Id como chave.
            // 3. Retorne o produto cadastrado em uma resposta HTTP de sucesso.
            // Dica: siga a mesma ideia do cadastro de perecíveis, mas use ProdutoEletronico.
            int novoId = _produtos.Count + 1;
            novoProduto.Id = novoId;
            _produtos[novoId] = novoProduto;
            return Ok(novoProduto);
        }

        // POST: api/Produtos/1/entrada
        [HttpPost("{id}/entrada")]
        public IActionResult Entrada(int id, [FromBody] MovimentoDTO dto)
        {
            // TODO:
            // 1. Verifique se existe um produto com o Id informado.
            // 2. Se não existir, retorne NotFound("Produto não encontrado.").
            if (!_produtos.ContainsKey(id))
            {
                return NotFound("Produto não encontrado.");
            }

            // 3. Recupere o produto armazenado no Dictionary.
            var produto = _produtos[id];

            // 4. Chame AdicionarEstoque(dto.Quantidade) para tentar adicionar a quantidade.
            // 5. Se o método retornar false, responda BadRequest("Quantidade inválida.").
            if (!produto.AdicionarEstoque(dto.Quantidade))
            {
                return BadRequest("Quantidade inválida.");
            }

            // 6. Se der certo, retorne o produto atualizado em uma resposta de sucesso.
            // Importante: não altere Quantidade diretamente. Use o método da classe Produto.
            return Ok(produto);
        }

        // POST: api/Produtos/1/saida
        [HttpPost("{id}/saida")]
        public IActionResult Saida(int id, [FromBody] MovimentoDTO dto)
        {
            // TODO:
            // 1. Verifique se existe um produto com o Id informado.
            // 2. Se não existir, retorne NotFound("Produto não encontrado.").
            if (!_produtos.ContainsKey(id))
            {
                return NotFound("Produto não encontrado.");
            }

            // 3. Recupere o produto armazenado no Dictionary.
            var produto = _produtos[id];

            // 4. Chame RetirarEstoque(dto.Quantidade) para tentar retirar a quantidade.
            // 5. Se o método retornar false, responda
            //    BadRequest("Quantidade inválida ou estoque insuficiente.").
            // 6. Se der certo, retorne o produto atualizado em uma resposta de sucesso.
            // Importante: não altere Quantidade diretamente. Use o método da classe Produto.
            if (!produto.RetirarEstoque(dto.Quantidade))
            {
                return BadRequest("Quantidade inválida ou estoque insuficiente.");
            }

            return Ok(produto);
        }
    }

    // Esta classe recebe os dados enviados no corpo da requisição
    // para as operações de entrada e saída de estoque.
    public class MovimentoDTO
    {
        // TODO:
        // Declare uma propriedade pública chamada Quantidade, do tipo int,
        // com get e set, para que a API consiga ler a quantidade enviada no JSON.
        public int Quantidade { get; set; }
    }
}