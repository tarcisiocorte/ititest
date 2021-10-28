
## Baixar e executar o projeto

 1. Por favor, use o DotNet Core versão 3.1
 2. Baixar ou clonar o projeto em alguma pasta
 3. Acesse a pasta do projeto
 4. Execute o comando abaixo para executar os testes
 
 ```dotnet test Iti.Tests/Iti.Tests.csproj```
 
 5. Execute o comando abaixo para executar a Api Web
 
 ```dotnet run --project Api/Iti.Api.csproj```
 
 Acesse pelo endereço: https://localhost:5001/index.html
 
 
 
 ## Sobre a Arquitetura
 #### Para o design do código foi usado Clean Archicteture com o detalhe que a validação de senha foi implementada na camada de dominio, uma vez que eu assumi que a validação de senha não serve só para a API, mas sim para  qualquer sistema que venha a ser adicionado ao projeto e queria usar esta regra.
 
 #### Um detalhe importante sobre a validação é o fato de usar Fluent Validation. Porém não foi implementado o ```RegisterValidatorsFromAssemblyContaining``` para que não altere o comportamento de retorno da Api, conforme especificado no enunciado do teste.
 
 ###
