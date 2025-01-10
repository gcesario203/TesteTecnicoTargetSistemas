// Respostas referentes aos questionamentos do teste técnico da empresa Target Systems

//1) Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0;
//Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; }
//Imprimir(SOMA);
//Ao final do processamento, qual será o valor da variável SOMA?
// Reposta: Valor 91

using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using TesteTecnicoTargetSistemas.Models;
using TesteTecnicoTargetSistemas.Utils;

var idx = 13;
int sum = 0;
int k = 0;
while (k < idx)
{
    k += 1;
    sum += k;
}

Console.WriteLine($"Resposta pergunta 1: Valor da soma é {sum}");


//2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.

//IMPORTANTE: Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código;

Console.WriteLine("Para resolver a questão 2, digite um número inteiro\n");

var quest2input = Console.ReadLine();

if(int.TryParse(quest2input, out var @int))
{
    Utils.Fibonnaci(@int);
}
else
{
    Console.WriteLine("Input inválido\n");
}

Console.WriteLine("Resposta questão 3");
//3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
//• O menor valor de faturamento ocorrido em um dia do mês;
//• O maior valor de faturamento ocorrido em um dia do mês;
//• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

//IMPORTANTE:
//a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
//b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;

var faturamentos = JsonSerializer.Deserialize<IEnumerable<FaturamentoModel>>(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Environment.ProcessPath), "dados.json")));

var faturamentosReais = faturamentos.Where(faturamento => faturamento.Valor > 0).ToList();

var menorFaturamento = faturamentosReais.MinBy(x => x.Valor);

var maiorFaturamento = faturamentosReais.MaxBy(x => x.Valor);

var mediaMensal = faturamentosReais.Sum(x => x.Valor) / faturamentosReais.Count;

var diasComFaturamentoMaiorQueAMedia = faturamentosReais.Where(faturamento => faturamento.Valor > mediaMensal);
Console.WriteLine($"Menor faturamento do mês: {menorFaturamento.Dia} - valor: {menorFaturamento.Valor}");
Console.WriteLine($"Maior faturamento do mês: {maiorFaturamento.Dia} - valor: {maiorFaturamento.Valor}");
Console.WriteLine($"Número de dias no mês que o faturamento foi maior que a media mensal {diasComFaturamentoMaiorQueAMedia.Count()} sendo eles,{String.Join(",", diasComFaturamentoMaiorQueAMedia.Select(x => x.Dia))} \n");

Console.WriteLine("Resposta questão 4");
//4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
//• SP – R$67.836,43
//• RJ – R$36.678,66
//• MG – R$29.229,88
//• ES – R$27.165,48
//• Outros – R$19.849,53

//Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.

var SP = 67836.43;
var RJ = 36678.66;
var MG = 29229.88;
var ES = 27165.48;
var Outros = 19849.53;

var receitaTotal = SP + RJ + MG + ES + Outros;

Console.WriteLine($"SP Recebeu por cento do valor total de {receitaTotal}: {Utils.CalculaPercentual(receitaTotal, SP)}%");
Console.WriteLine($"RJ Recebeu por cento do valor total de {receitaTotal}: {Utils.CalculaPercentual(receitaTotal, RJ)}%");
Console.WriteLine($"MG Recebeu por cento do valor total de {receitaTotal}: {Utils.CalculaPercentual(receitaTotal, MG)}%");
Console.WriteLine($"ES Recebeu por cento do valor total de {receitaTotal}: {Utils.CalculaPercentual(receitaTotal, ES)}%");
Console.WriteLine($"Outros estados receberam por cento do valor total de {receitaTotal}: {Utils.CalculaPercentual(receitaTotal, Outros)}%\n");

Console.WriteLine("Resposta questão 5");

//5) Escreva um programa que inverta os caracteres de um string.

Console.WriteLine("Digite uma cadeia de caracteres qualquer: ");

var inputquest5 = Console.ReadLine();

Console.WriteLine($"Sequência de caracteres invertida: {String.Join("", inputquest5.Reverse())}");