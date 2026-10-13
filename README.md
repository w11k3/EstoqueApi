### 5. Perguntas de reflexão

**1. Por que `Quantidade` não tem `set`? O que poderia dar errado se tivesse?**

A quantidade é alterada apenas pelos métodos AdicionarEstoque e RetirarEstoque. Se tivesse set público, seria possível definir valores negativos ou alterar o estoque sem validação.

**2. Que código você deixou de repetir graças à herança?**

Os atributos e métodos de Produto, como Id, Nome, Preco, Quantidade, AdicionarEstoque e RetirarEstoque em ProdutoPerecivel e ProdutoEletronico.

**3. Por que a validação do preço fica dentro de `Produto`, e não no controller?**

Porque a validação faz parte das regras da classe Produto e o preço é validado sem depender de onde o produto for criado ou alterado evitando duplicação de código.

### Tabela de testes — Controle de Estoque

| Teste | Resultado esperado | Resultado obtido |
|---|---|---|
| Criar produto com preço negativo | O preço deve ser armazenado como `0`. | Preencher após testar |
| Criar produto com nome vazio ou espaços | O nome deve ser `"Produto sem nome"`. | Preencher após testar |
| Adicionar 10 unidades e retirar 3 | O estoque final deve ser `7`. | Preencher após testar |
| Retirar 50 unidades sem estoque suficiente | HTTP `400 Bad Request`. | Preencher após testar |
| Adicionar quantidade `0` | HTTP `400 Bad Request`. | Preencher após testar |
| Listar produtos | HTTP `200 OK`, incluindo `DataValidade` para perecíveis e `GarantiaMeses` para eletrônicos. | Preencher após testar |
| Buscar produto com ID inexistente (`99`) | HTTP `404 Not Found`. | Preencher após testar |