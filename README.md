# 🧮 Bleach: Soul Resonance - Build Calculator & Engine (`bleach-rpg-build-calculator`)

## 📖 Sobre
Este é o repositório (Cliente/Motor) do projeto **Bleach: Soul Resonance -> Game Guide**.
Aqui reside o software principal, definindo a camada de domínio, regras de negócio, a interface do catálogo e a calculadora avançada de *min-maxing*.

**🔗 Ecossistema do Projeto:**
Este repositório atua como o cliente final do ecossistema e consome os dados processados pelos outros serviços:
- 🌐 **API de Dados:** A fonte primária de dados estruturados em tempo de execução vem da **[API REST (bleach-rpg-catalog-api)](https://github.com/DiogoDomi/bleach-rpg-catalog-api)**.
- 🗄️ **Data Pipeline:** Os arquivos `.csv` utilizados para testes rápidos e prototipagem local são gerados pelo **[Data Pipeline em Python (bleach-rpg-data-info)](https://github.com/DiogoDomi/bleach-rpg-data-info)**.

## ⚙️ Funcionalidades e Workflow
- **Catálogo:** Visualização detalhada de todos os personagens, armas, itens de stamps, custos de maximização por classe, e custos de roletagem com as diferentes moedas do jogo.
- **Calculadora de Min-Maxing:** Ferramenta interativa onde o usuário insere os dados atuais de sua conta (nível, boundary, itens) para calcular o custo exato de progressão.
- **Consumo de Dados:**
  - Consulta primária: Consome os JSONs através dos endpoints da `bleach-rpg-catalog-api`.
  - Prototipagem e Testes: Capacidade de ler os arquivos `.csv` para testar novas implementações de modelagem rapidamente antes de irem para a API.
- **Nota de Domínio:** O software atua de forma estática e auxiliar, sem coletar dados persistentes dos usuários.

## 🛠️ Tecnologias
- **Linguagem:** C#

