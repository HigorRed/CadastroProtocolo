# Cadastro de Protocolo

Este projeto é uma aplicação web para gerenciamento de protocolos, onde você pode criar, editar, listar e excluir protocolos associados a clientes. O sistema também permite o registro de ações de acompanhamento dos protocolos através de uma tabela de acompanhamento, chamada `ProtocoloFollow`.

## Funcionalidades

- **Cadastro de Protocolos e Clientes :** Criação de protocolos com informações como título, descrição, data de abertura, data de fechamento e status (Aberto, Em Andamento, Concluído).
- **Edição e Exclusão de Protocolos e Clientes :** Permite alterar as informações de um protocolo ou cliete  existente ou excluí-los.
- **Acompanhamento de Protocolos e Clientes :** Cada protocolo pode ter um histórico de ações registradas, facilitando o acompanhamento das mudanças.


## Tecnologias Utilizadas

- **ASP.NET Core 8:** Framework para construção de aplicações web.
- **Entity Framework Core:** ORM utilizado para interagir com o banco de dados.
- **SQL Server:** Banco de dados utilizado para armazenar os dados da aplicação.
- **HTML/CSS/Bootstrap:** Tecnologias utilizadas para a criação da interface de usuário.

## Instalação

### Pré-requisitos

- .NET SDK 6 ou superior
- SQL Server ou qualquer outro banco de dados SQL compatível com EF Core

### Passo a Passo

1. Clone este repositório para sua máquina local:
   ```bash
   git clone https://github.com/HigorRed/CadastroProtocolo.git
