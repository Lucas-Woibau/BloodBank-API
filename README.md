# BloodBank.API

Bem-vindo ao **BloodBank.API**, a API responsável por gerenciar o fluxo de doadores, doações e demais operações do sistema BloodBank.  
Este projeto segue princípios de **DDD (Domain-Driven Design)**, **Clean Architecture** e boas práticas modernas de desenvolvimento com **ASP.NET Core**.

---

## 🚀 Tecnologias Utilizadas
- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server 
- MediatR  
- FluentValidation  
- Swagger / OpenAPI  

---

## 📁 Estrutura do Projeto (Clean Architecture)
- BloodBank.API -> Controllers, Configurações, Middlewares, Swagger
- BloodBank.Application -> Casos de uso, DTOs, Handlers, Validadores, Interfaces
- BloodBank.Domain -> Entidades, Value Objects, Agregados, Regras de Domínio
- BloodBank.Infrastructure -> Persistência, Migrações, Mapeamentos, Repositórios

---

## 📦 Funcionalidades Principais

### 🔹 Donor (Doador)
- Criar doador  
- Atualizar informações  
- Buscar por ID  
- Listar todos os doadores
- Listar histórico de doações
- Preenchimento automático de endereço via serviço de CEP  

### 🔹 Donation (Doação)
- Registrar nova doação  
- Listar doações por doador  
- Ordenação por data (mais recentes primeiro)  

### 🔹 BloodStock (Estoque de Sangue)
- Registrar entrada de estoque automaticamente após uma doação  
- Validar tipos sanguíneos (A+, A-, B+, B-, AB+, AB-, O+, O-)  
- Evitar inconsistências com Value Objects de BloodType  
- Consultar estoque total  
- Consultar estoque por tipo sanguíneo  
- Atualizações automáticas usando eventos de domínio (Domain Events)  
- Regras de domínio para impedir contagem negativa de bolsas  

### 🔹 Address (Endereço)
- Value Object associado ao agregado `Donor`  
- Preenchido automaticamente por serviço externo  

---

## 🏛️ Decisões de Arquitetura

- Domain Events
- Clean Architecture
- CQRS com MediatR
- Value Objects imutáveis
- Aggregates roots
- Repository Pattern
- Regras de domínio isoladas
  
---

## 📄 Padrões Adotados

- DDD
- SOLID
- Clean Architecture
- CQRS (simplificado)
- Entity Configuration por classe
