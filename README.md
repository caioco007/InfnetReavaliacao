# InfnetReavaliacao

## 1. Quais os principais objetivos da Segurança no Processo de Desenvolvimento de Software?
Confidencialidade: Garantir que apenas as pessoas autorizadas tenham acesso às informações sensíveis.  
Integridade: Manter os dados e sistemas íntegros, evitando alterações não autorizadas.  
Disponibilidade: Assegurar que os sistemas e dados estejam disponíveis quando necessário.  
Autenticidade: Verificar a identidade dos usuários e sistemas.  
Não repúdio: Garantir que ações realizadas por um usuário possam ser comprovadas.  

## 2. Qual a importância de um código bem escrito e documentado?
Um código bem escrito é fundamental para facilitar a manutenção, a colaboração e a escalabilidade de um software. Documentação clara auxilia desenvolvedores a entender o código, acelera o processo de correção de erros e ajuda na integração de novos membros da equipe.

## 3. Qual a importância de gerenciamento de código?
O gerenciamento de código é essencial para controlar as alterações no código-fonte, permitindo o acompanhamento de versões, colaboração eficiente, resolução de conflitos e garantia de que o código seja sempre estável e funcional.

## 4. Qual a importância de testes automatizados?
Testes automatizados são cruciais para garantir a qualidade do software. Eles ajudam a identificar problemas rapidamente, aceleram o desenvolvimento, asseguram que as funcionalidades existentes continuem funcionando após as alterações e permitem refatorações com confiança.

## 5. Explique com suas palavras o que é e como funciona o TDD (Test Driven Development).
O TDD é uma abordagem de desenvolvimento que prioriza a criação de testes antes da escrita do código real. O ciclo do TDD segue três passos: escrever um teste que descreve o comportamento desejado, rodar o teste (que deve falhar inicialmente), e, em seguida, escrever o código necessário para fazer o teste passar. Isso leva a um desenvolvimento orientado por requisitos e cria um código mais robusto e testável.

## 6. Explique com suas palavras os seguintes princípios (S.O.L.I.D, Clean Code):
Responsabilidade Única (Single Responsibility Principle): Uma classe deve ter apenas um motivo para mudar, ou seja, deve ter uma única responsabilidade.

Aberto-Fechado (Open-Close Principle): O software deve ser aberto para extensão, mas fechado para modificação. Novas funcionalidades devem ser adicionadas sem alterar o código existente.

Liskov (Liskov Substitution Principle): Subtipos devem ser substituíveis por seus tipos base sem afetar a integridade do programa. Isso se relaciona com herança e polimorfismo.

Segregação de Interfaces (Interface Segregation Principle): Uma classe não deve ser forçada a implementar interfaces que não usa. A interface de uma classe deve ser específica para as necessidades dessa classe.

Inversão de Dependência (Dependency Inversion Principle): Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações. Além disso, detalhes devem depender de abstrações, não o contrário.
