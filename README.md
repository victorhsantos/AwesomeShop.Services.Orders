# AwesomeShop.Services.Customers - Microsserviços com ASP.NET Core

A arquitetura do AwesomeShop, sistema de e-commerce baseado na arquitetura de microsserviços, contém 6 microsserviços:
- [Customers](https://github.com/victorhsantos/AwesomeShop.Services.Customers)
- [Products](https://github.com/victorhsantos/AwesomeShop.Services.Products) 
- [Orders](https://github.com/victorhsantos/AwesomeShop.Services.Orders)
- [Payments](https://github.com/victorhsantos/AwesomeShop.Services.Payments)
- [Notifications](https://github.com/victorhsantos/AwesomeShop.Services.Notifications)
- [API Gateway](https://github.com/victorhsantos/AwesomeShop.Services.ApiGateway)

## Tecnologias, práticas e arquitetura utilizadas
- ASP.NET Core com .NET 5
- Arquitetura de Microsserviços
- Princípios do Domain-Driven Design
- MongoDB
- Clean Architecture
- CQRS
- RabbitMQ e arquitetura orientada a eventos
- API Gateway com Ocelot 
- Service Discovery com Consul
- Observabilidade com Prometheus e Grafana

## Funcionalidades do Orders
- Cadastro
- Busca por Id
- Atualização de Status consumindo evento PaymentAccepted
