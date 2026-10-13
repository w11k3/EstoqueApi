# EstoqueApi

A RESTful Web API for inventory management, developed with C# and ASP.NET Core.

## About the Project

EstoqueApi is an academic project developed to practice backend development, object-oriented programming, inheritance, encapsulation, and data validation using C# and ASP.NET Core.

The application models different types of products and implements inventory management rules to ensure that stock operations follow the defined business logic.

## Technologies

- C#
- .NET
- ASP.NET Core Web API
- HTTP

## Project Structure

```text
EstoqueApi/
├── Controllers/
│   └── ProdutosController.cs
├── Models/
│   └── Produto.cs
├── Program.cs
├── EstoqueApi.csproj
├── EstoqueApi.http
├── .gitignore
└── README.md
```

*The structure above highlights the main files. Additional model files may exist in the project.*

## Features

- Product modeling using object-oriented programming.
- Encapsulation of inventory quantity.
- Stock addition and removal operations.
- Price validation.
- Inheritance for specialized product types.
- HTTP responses for API operations.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/w11k3/EstoqueApi.git
   ```

2. Navigate to the project directory:

   ```bash
   cd EstoqueApi
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

The terminal will display the local address where the application is running.

## API Testing

The `EstoqueApi.http` file can be used to send HTTP requests and test the API endpoints in a compatible development environment.

## 5. Perguntas de reflexão

### 1. Por que `Quantidade` não tem `set`? O que poderia dar errado se tivesse?

A quantidade é alterada apenas pelos métodos `AdicionarEstoque` e `RetirarEstoque`. Se tivesse um `set` público, seria possível definir valores negativos ou alterar o estoque sem validação.

### 2. Que código você deixou de repetir graças à herança?

Os atributos e métodos de `Produto`, como `Id`, `Nome`, `Preco`, `Quantidade`, `AdicionarEstoque` e `RetirarEstoque`, são reutilizados em `ProdutoPerecivel` e `ProdutoEletronico`.

### 3. Por que a validação do preço fica dentro de `Produto`, e não no controller?

Porque a validação faz parte das regras da classe `Produto`. Dessa forma, o preço é validado independentemente de onde o produto for criado ou alterado, evitando duplicação de código.

## Tabela de testes — Controle de Estoque

| Teste | Resultado esperado | Resultado obtido |
|---|---|---|
| Criar produto com preço negativo | O preço deve ser armazenado como `0`. | Preencher após testar |
| Criar produto com nome vazio ou espaços | O nome deve ser `"Produto sem nome"`. | Preencher após testar |
| Adicionar 10 unidades e retirar 3 | O estoque final deve ser `7`. | Preencher após testar |
| Retirar 50 unidades sem estoque suficiente | HTTP `400 Bad Request`. | Preencher após testar |
| Adicionar quantidade `0` | HTTP `400 Bad Request`. | Preencher após testar |
| Listar produtos | HTTP `200 OK`, incluindo `DataValidade` para perecíveis e `GarantiaMeses` para eletrônicos. | Preencher após testar |
| Buscar produto com ID inexistente (`99`) | HTTP `404 Not Found`. | Preencher após testar |

## 7. Desafio extra — Implementações

### DELETE `/api/produtos/{id}`

Endpoint para remover um produto pelo seu ID.

- Retorna `204 No Content` quando a exclusão é realizada.
- Retorna `404 Not Found` quando o produto não existe.

### Propriedade `ValorEmEstoque`

Propriedade somente de leitura da classe `Produto`, calculada pela multiplicação do preço pela quantidade disponível.

```csharp
public decimal ValorEmEstoque => Preco * Quantidade;
```

**Teste realizado:** notebook com preço de R$ 3.500,00 e 10 unidades em estoque.

Resultado esperado e obtido: `35000`.

### Propriedade `Vencido`

Propriedade somente de leitura da classe `ProdutoPerecivel`, que retorna `true` quando a data de validade é anterior à data atual.

```csharp
public bool Vencido => DataValidade.Date < DateTime.Today;
```

**Testes realizados:**

- Leite com validade em 12/10/2026: `true`.
- Iogurte com validade em 20/10/2026: `false`.

Os resultados obtidos corresponderam aos resultados esperados.

## Author

**Willian Kauê da Cruz Campos**

- GitHub: [@w11k3](https://github.com/w11k3)
- LinkedIn: [Willian Campos](https://www.linkedin.com/in/willian-campos-764b4331b/)

---

This project is part of my Software Engineering studies and my ongoing development of backend programming skills.