## 🚀 Tecnologias Utilizadas

- **Angular** 
- **C#** 
- **ASP.NET Core**
- **Entity Framework Core In-Memory**
- **XUnit**
- **Moq** 
- **TypeScript**
- **Reactive Forms**
- **Bootstrap**

## 📑 Funcionalidades

- **Cadastro de Usuários:** Tela para criar uma nova conta com validações de campos
- **Login de Usuários:** Tela de login com verificação de credenciais
- **Validação de Usuário Duplicado:** Verificação se o login informado no cadastro já existe no banco de dados
- **Validação de Campos Obrigatórios:** Mensagens claras para campos ausentes
- **Validação de Equidade de Senha:** Confirmação de senhas iguais durante o cadastro
- **Tratamento de Erros:** Feedback adequado para falhas no login e cadastro
- **Mensagens de Sucesso:** Informações claras para operações bem-sucedidas
- **Testes Unitários:** Exemplos de testes realizados na API C#


## 📋 Observações sobre o Projeto


- **Usuário Pré-Cadastrado:** Para atender ao requisito 4 descrito abaixo, ao iniciar a API C#, é criado o usuário abaixo no banco de dados:

  - Login: **admin**
  - Senha: **P@$$W0RD**

4)	Escreva um programa que teste uma senha e para cada leitura de senha incorreta informada, escrever a mensagem "Senha Invalida". Quando a senha for informada corretamente deve ser impressa a mensagem "Acesso Permitido" e o algoritmo encerrado. Considere que a senha correta é o valor P@$$W0RD."

- **Limitação com Entity Framework Core In-Memory:** Esse banco ignora constraints. Portanto, foi necessário realizar uma busca prévia pelo login antes de permitir o cadastro. Em um cenário real, as constraints evitariam esse tipo de verificação.

- **Swagger:** Foi adicionado o Swagger no projeto, portanto é possível testar somente a API de forma mais fácil através da url http://localhost:5145/swagger/index.html

## 🚀 Inicialização

Certifique-se de iniciar tanto o back-end quanto o front-end para o funcionamento correto da aplicação. Para dúvidas ou esclarecimentos adicionais, fico à disposição!