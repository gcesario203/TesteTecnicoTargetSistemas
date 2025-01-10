using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoTargetSistemas.Utils;

public abstract class Utils
{

    public static void Fibonnaci(int number,int actualNumber = 0, int lastNumber = 0)
    {
        if(number < 0)
        {
            Console.WriteLine("Número não pertence a sequencia de Fibonacci\n");

            return;
        }

        if (actualNumber == number || number == 0)
        {
            Console.WriteLine("Número pertence a sequência de fibonnaci!\n");

            return;
        }

        if (actualNumber == 0)
        {
            actualNumber = 1;
        }

        var tempActualNumber = actualNumber;

        actualNumber += lastNumber;

        lastNumber = tempActualNumber;

        if (actualNumber > number)
        {
            Console.WriteLine("Número não pertence a sequencia de Fibonacci\n");

            return;
        }

        Fibonnaci(number, actualNumber, lastNumber);
    }

    public static double CalculaPercentual(double valorTotal, double valorQueOEstadoRecebeu)
        => (valorQueOEstadoRecebeu / valorTotal) * 100;
}
