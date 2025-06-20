# StockTrack

StockTrack é um sistema simples de controle de estoque desenvolvido em C# com .NET Core e Entity Framework Core, voltado para ambientes didáticos, pequenos negócios e aprendizado de práticas modernas de desenvolvimento backend.

## Funcionalidades

- Cadastro de produtos por tipo (Eletrônico, Alimento, Vestuário) e classificação por categoria
- Identificação única dos produtos por GUID e código curto numérico de 6 dígitos para fácil consulta
- Registro de movimentações de estoque (entrada e saída)
- Busca avançada de produtos
- Estrutura extensível com padrão DDD (Domain-Driven Design)
- Persistência via SQLite com suporte a migrations

## Diagrama da Modelagem do Domínio

```
+-------------------+         +-------------------+         +-------------------+
|    Categoria      |         |     Produto       |         |   Movimentacao    |
|-------------------|         |-------------------|         |-------------------|
| - Id: Guid        |<>------>| - Id: Guid        |<------->| - Id: Guid        |
| - Nome: string    |         | - CodigoCurto     |         | - ProdutoId: Guid |
+-------------------+         | - Nome: NomeProd  |         | - Quantidade      |
                              | - Categoria       |         | - TipoMovimentacao|
                              | - Estoque         |         | - Data            |
                              +-------------------+         +-------------------+
                               <<abstract>>                   
                              ^  ^         ^                  
                              |  |         |                  
                              |  |         |                  
                +-------------+  |         +------------------+
                |                |                            |
        +---------------+ +---------------+           +-----------------+
        |  Eletronico   | |   Alimento    |           |   Vestuario     |
        +---------------+ +---------------+           +-----------------+
        | - Voltagem    | | - DataValidade|           | - Tamanho       |
        +---------------+ +---------------+           +-----------------+
```

## Estrutura do Projeto

```
StockTrack.ConsoleApp/
├── Application/
│   ├── Services/
│   └── App/
├── Domain/
│   ├── Entities/
│   ├── Factories/
│   ├── Repositories/
│   ├── Services/
│   └── ValueObjects/
├── Infrastructure/
│   ├── Repositories/
│   └── StockTrackDbContext
├── Migrations/
├── Interface
└── README.md
```

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [dotnet-ef CLI](https://learn.microsoft.com/ef/core/cli/dotnet)

## Como rodar o projeto

1. **Clone o repositório:**

- Via SSH:
   ```bash
   git clone git@github.com:leoantunesfm/StockTrack.git
   ```

- Via HTTPS:
   ```bash
   git clone https://github.com/leoantunesfm/StockTrack.git
   ```
   

2. **Abra o arquivo de solução com o Visual Studio (Prefencialmente versão 2022):**
   ```bash
   ..\StockTrack\FillGaps.StockTrack.ConsoleApp\FillGaps.StockTrack.ConsoleApp.sln
   ```

3. **Ctrl + F5 para executar**

- Isso compilará e executará o projeto em modo sem depuração, e você verá a aplicação de console sendo iniciada.
- O projeto conta com persistencia com SQLite, EF Core e migrations. Ao executar o projeto o banco de dados será criado.
- Nos seus testes os registros cadastrados não serão perdidos ao finalizar a execução da aplicação.


## Gerenciamento do Banco de Dados

Sempre que alterar entidades ou ValueObjects que refletem no banco de dados, crie uma nova migration:

```bash
dotnet ef migrations add NomeDaMigration --project StockTrack.ConsoleApp
dotnet ef database update --project StockTrack.ConsoleApp
```

## Exemplos de Uso

- Ao cadastrar um produto, será gerado um código curto numérico (ex: `018273`) para consultas rápidas.
- O menu principal permite listar produtos, registrar movimentações, e buscar produtos por múltiplos critérios.

## Contribuindo

1. Faça um fork do projeto
2. Crie sua branch (`git checkout -b feature/nome-feature`)
3. Commit suas alterações (`git commit -am 'Adiciona nova feature'`)
4. Faça push para sua branch (`git push origin feature/nome-feature`)
5. Abra um Pull Request

---