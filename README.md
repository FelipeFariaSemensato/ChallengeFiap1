# Odontoguard

## Definição do Projeto

### Objetivo do Projeto

O objetivo deste projeto é desenvolver um aplicativo para a Odontoprev que incentive os pacientes a adotarem hábitos de higiene bucal saudáveis por meio de um sistema de tarefas gamificadas. O projeto visa resolver a falta de engajamento dos pacientes em suas rotinas de cuidados bucais, fornecendo feedback direto de dentistas e recompensas por comportamentos preventivos.

### Escopo

O aplicativo incluirá as seguintes funcionalidades principais:

- Sistema de tarefas gamificadas para incentivar a prevenção.
- Envio de fotos como comprovação das tarefas realizadas.
- Feedback regular e personalizado de dentistas.
- Canal de comunicação direto entre pacientes e dentistas.
- Programa de recompensas baseado em níveis para engajar os usuários.

### Requisitos Funcionais e Não Funcionais

#### Requisitos Funcionais

1. Os pacientes podem visualizar e completar tarefas diárias/semanais.
2. O envio de fotos para comprovar a realização das tarefas.
3. Feedback dos dentistas com orientações personalizadas.
4. Canal de mensagens entre pacientes e dentistas.
5. Sistema de recompensas baseado em pontos.

#### Requisitos Não Funcionais

1. A aplicação deve ser responsiva e acessível em dispositivos móveis.
2. Deve garantir a segurança e privacidade dos dados dos usuários.
3. A aplicação deve ter alta disponibilidade e performance.

## Desenho da Arquitetura

### Clean Architecture

A aplicação seguirá os princípios da Clean Architecture, separando as responsabilidades e mantendo o código desacoplado. As diferentes camadas da aplicação são organizadas da seguinte forma:

#### Camadas da Aplicação

- **Apresentação**: Responsável pela interface do usuário e pela interação com o aplicativo. 
- **Aplicação**: Contém os serviços e casos de uso que gerenciam a lógica do aplicativo.
- **Domínio**: Onde residem os modelos e as regras de negócio do sistema.
- **Infraestrutura**: Lida com o acesso a dados, integrações com APIs externas e gerenciamento de banco de dados.

