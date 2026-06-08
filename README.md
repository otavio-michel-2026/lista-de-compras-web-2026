# Lista de Compras Web

**Atividade 16 - [Academia do Programador](https://www.academiadoprogramador.net/inicio) 2026**

<p align="center">
  <img src="https://i.imgur.com/bE8N1xl.gif">
</p>

"Maria faz as compras da família toda semana, mas sempre esquece algum item ou compra coisas que já tem
em casa. Por isso, resolveu pedir ajuda para organizar melhor as compras.

Assim foi criado o projeto Lista de Compras, um sistema simples para cadastrar produtos, organizar listas e
registrar as compras realizadas. Os alunos da Academia do Programador foram contratados para desenvolver a
aplicação."

## Funcionalidades

- Cadastro, edição, exclusão e visualização de categorias
- Cadastro, edição, exclusão e visualização de produtos
- Controle de listas de compras:
  - Cadastro, edição, exclusão e visualização de listas
  - Adição de produtos na lista
  - Remoção de produtos da lista
  - Conclusão de itens da lista
  - Reabertura automática de item concluído ao adicionar o mesmo produto novamente
  - Visualização dos itens e do valor total da lista

## Regras das Listas

- Ao adicionar um produto que já existe na lista e ainda está aberto, a quantidade informada é somada à quantidade atual. Caso esteja concluído, o item é reaberto e sua quantidade passa a ser igual à quantidade informada.
- Uma lista vazia pode ser excluída, já uma com itens só pode ser excluída quando todos os itens estiverem concluídos.

## Persistência de Dados

Os dados são armazenados em arquivo JSON no caminho:

`%LocalAppData%/ListaDeCompras/dados.json`

## Como Executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

### Passos

1. Abra a pasta do repositório.
2. Restaure e compile (opcional):

```bash
dotnet build ListaDeCompras.slnx
```

3. Execute a aplicação:

```bash
dotnet run --project ListaDeCompras.WebApp
```
