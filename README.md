# Programação Visual Básica

Dois programas em C# da disciplina de Programação Visual Básica, no 2º ano do
ensino médio técnico: um de console e um com interface gráfica em WPF.

## Programas

### numeros-pico/

Aplicação de console. Lê números até o usuário digitar 0 e identifica quais são
"números pico": aqueles cujos dígitos sobem e depois descem, sem voltar a subir.
Ao final mostra quantos picos apareceram, o maior dígito entre eles, a média dos
números que não são pico e o percentual de picos sobre o total.

### estatistica-wpf/

Aplicação de janela. O usuário digita um valor por linha numa caixa de texto e,
ao clicar em Calcular, a janela mostra a quantidade de valores, o menor, o maior,
a média, a variância amostral e o desvio padrão, todos com duas casas decimais.

## Como executar

Requer o SDK do .NET 8 ou superior. O projeto WPF só roda no Windows.

    cd numeros-pico
    dotnet run

    cd estatistica-wpf
    dotnet run

## Tecnologias

C# e WPF (.NET 8), sem bibliotecas externas.

Projeto desenvolvido em equipe.
