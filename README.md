# API de Máquina de Caixa Eletrônico

## Descrição:

Esta API simula o funcionamento básico de uma máquina de caixa eletrônico.

## Detalhes Técnicos:

A API é construída utilizando uma arquitetura em camadas, seguindo o padrão repository, implementando injeção de dependência, CQRS, e é exposta através de um único controller para simplificar o entendimento.

O Entity Framework Core é utilizado como ORM, e a implementação do padrão CQRS é realizada com o auxílio do Mediatr.

## Pontos de Melhoria Futura:

Para aprimorar esta API, poderiam ser adicionadas mais funcionalidades para permitir um controle mais detalhado das operações, como armazenar as transações, criar uma entidade para o usuário que realiza o saque, implementar caching para a busca das notas do caixa, e adicionar autenticação e autorização para as rotas. Por questões de simplicidade, esta primeira versão não inclui essas implementações.

## Instruções:

Para executar o projeto, certifique-se de ter o Docker instalado e em execução em sua máquina.

Siga os passos abaixo:

1. Clone o repositório para a sua máquina.
2. Execute a solução.
3. Inicie o projeto utilizando o botão de docker compose no Visual Studio.
