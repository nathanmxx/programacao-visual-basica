# Programação Visual Básica

Três programas em C# da disciplina de Programação Visual Básica, no 2º ano do
ensino médio técnico: um de console e dois com interface gráfica em WPF.

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

### calculadora-hohmann/

Calculadora de trajetória interplanetária. Recebe a distância da origem e do
destino até o Sol, a massa da nave e o impulso específico do motor, e calcula a
transferência de Hohmann entre as duas órbitas:

- tempo de viagem, em dias e em meses
- delta-V total, somando a manobra de saída e a de chegada
- combustível necessário, em quilos e em toneladas, pela equação de Tsiolkovski

Usa o parâmetro gravitacional do Sol e trata as distâncias em milhões de
quilômetros. Para a transferência da Terra a Marte (149,6 e 227,9), devolve 259
dias e 5,591 km/s de delta-V.

## Como executar

Requer o SDK do .NET 8 ou superior. Os projetos WPF só rodam no Windows.

    cd numeros-pico
    dotnet run

    cd estatistica-wpf
    dotnet run

    cd calculadora-hohmann
    dotnet run

## Tecnologias

C# e WPF (.NET 8), sem bibliotecas externas.

Projeto desenvolvido em equipe.
