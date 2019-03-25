Desafio  - Teste de backend TrunckPad

Rodar a api entrar na pasta Release
digitar no pront de comando > dotnet TrunckPad.Presentation.Api.dll

Requisitos do sistema:
-  Asp.net core 2.1.2 C#

-  MongoDB.Driver 2.8.0
0 – Presentation
	- Nessa camada temos os controllers Apis
1 – Application
	- Nessa camada temos a Aplicação que faz a ponte entre a camada de Domino e a camada de Api
2 – Dominio
	- Nessa camada encontram-se as regras de negócios, ela faz a ponte entre a aplicação e o contexto (Acesso ao banco de dados)
	- Dentro da Pasta Entitys estão os objetos referente as tabelas do banco de dados
4 – Infra
	4.1 Data– Camada de acesso ao banco de dados. A configuração de acesso ao MongoDb está dentro da pasta Context no arquivo ContextTrunckPad.
	Dentro da pasta Repository estão os repositórios com os seus cruds e consultas.
	4.2 CrossCutting - Essa camada é responsável pela injeção de dependência.
5 Test – Camada de testes 

Rotas:
TipoCaminhao
Get - http://localhost:65373/api/tipoCaminhao
Get - http://localhost:65373/api/tipoCaminhao/ObjectId	
Post - http://localhost:65373/api/tipoCaminhao
Put - http://localhost:65373/api/tipoCaminhao/ObjectId	
Delete http://localhost:65373/api/tipoCaminhao/ObjectId
Caminhomeiro
Get - http://localhost:65373/api/ caminhoneiro
Get - http://localhost:65373/api/ caminhoneiro/ObjectId
Get - http://localhost:65373/api/ caminhoneiro/ getVeiculoProprio	
Post - http://localhost:65373/api/ caminhoneiro
Put - http://localhost:65373/api/ caminhoneiro/ObjectId	
Delete http://localhost:65373/api/ caminhoneiro/ObjectId
Endereco
Get - http://localhost:65373/api/endereco
Get - http://localhost:65373/api/endereco/ObjectId	
Post - http://localhost:65373/api/endereco 
Put - http://localhost:65373/api/endereco/ObjectId	
Delete http://localhost:65373/api/endereco/ObjectId
Chekin
Get - http://localhost:65373/api/checkin
Get - http://localhost:65373/api/checkin/ObjectId
Get - http://localhost:65373/api/GetCaminhoneiroSemCarga/DateTime
Get - http://localhost:65373/api/GetCaminhoneiros/DateTime
Post - http://localhost:65373/api/checkin/DateTime inicio/DateTime termino 
Put - http://localhost:65373/api/checkin/ObjectId	
Delete http://localhost:65373/api/checkin/ObjectId

	




