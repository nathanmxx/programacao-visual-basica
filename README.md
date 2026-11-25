# Programação Visual Básica

Quatro programas em C# da disciplina de Programação Visual Básica, no 2º ano do
ensino médio técnico: um de console e três com interface gráfica em WPF.

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

### consultorio-imc/

Cadastro de pacientes de um consultório de fisioterapia, com cálculo do Índice
de Massa Corporal. Cada pessoa recebe um Id gerado sozinho, e o IMC é
classificado em seis faixas, de Magreza a Obesidade Grau III. Os botões
cadastram, consultam, alteram e excluem pelo Id, e uma lista mostra o peso de
todos os cadastrados.

Os dados ficam num arquivo `pessoas.json` ao lado do executável, lido ao abrir
o programa e gravado a cada alteração. O JSON é montado e lido pelo próprio
código, sem biblioteca. O botão de relatório gera `relatorio_imc.html`, com a
tabela de pessoas e um gráfico polar da média do IMC em cada faixa, feito com
Plotly.

Diferente dos outros, este projeto é em .NET Framework 4.8.

## Como executar

Requer o SDK do .NET 8 ou superior. Os projetos WPF só rodam no Windows.

    cd numeros-pico
    dotnet run

    cd estatistica-wpf
    dotnet run

    cd calculadora-hohmann
    dotnet run

O consultorio-imc abre no Visual Studio com a carga de desenvolvimento para desktop:
basta abrir `ConsultorioIMC.sln` e apertar F5.

## Tecnologias

C# e WPF, em .NET 8 e, no consultório, .NET Framework 4.8. Sem bibliotecas
externas; o gráfico do relatório carrega o Plotly pela internet.

Projeto desenvolvido em equipe.
