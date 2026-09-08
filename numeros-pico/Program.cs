using System;

Console.WriteLine("PROGRAMA PARA LEITURA DE NÚMEROS PICOS");
Console.WriteLine("-------------------------------------------");

int numdig;
int qtdnum = 0;
int qtdnpic = 0;

int maiorDigitoPico = 0;

int somaNaoPico = 0;
int qtdNaoPico = 0;

do
{

    do
    {
        Console.WriteLine("Insira um número (0 para encerrar):");
        numdig = int.Parse(Console.ReadLine());

        if (numdig < 0)
        {
            Console.WriteLine("Número inválido. Por favor, insira um número não negativo.");
        }

    } while (numdig < 0);

    if (numdig == 0)
        break;

    qtdnum++;

    int aux = numdig;

    int anterior = aux % 10;
    aux /= 10;

    bool subindo = false;
    bool descendo = false;
    bool valido = true;


    while (aux > 0)
    {
        int atual = aux % 10;

        if (atual > anterior) 
        {
            subindo = true;
            if (descendo)
            {
                valido = false;
                break;
            }
        }
        else if (atual < anterior)
        {
            descendo = true;
        }

        anterior = atual;
        aux /= 10;
    }

    if (valido && subindo && descendo)
    {

        qtdnpic++;
        int copdig = numdig;
        while (copdig > 0)
        {
            int dig = copdig % 10;
            if (dig > maiorDigitoPico)
                maiorDigitoPico = dig;

            copdig /= 10;
        }
    }
    else
    {
        somaNaoPico += numdig;
        qtdNaoPico++;
    }

} while (true);


double mediaNaoPico = 0;
if (qtdNaoPico > 0)
    mediaNaoPico = (double)somaNaoPico / qtdNaoPico;

double percentualPico = 0;
if (qtdnum > 0)
    percentualPico = (double)qtdnpic * 100 / qtdnum;

Console.WriteLine("-------------------------------------------");
Console.WriteLine("Quantidade de números pico: " + qtdnpic);
Console.WriteLine("Maior dígito entre os picos: " + maiorDigitoPico);
Console.WriteLine("Média dos não picos: " + mediaNaoPico);
Console.WriteLine("Percentual de picos: " + percentualPico + "%");
