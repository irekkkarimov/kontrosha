namespace kr;

public class Program
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        var matrix = MatrixGenerate(length);
        var oddMatrix1 = OddMatrixFiller(length, length);
        var oddMatrix2 = OddMatrixFiller(length, length);
        //var inputtedMatrix = MatrixRead(@"C:\Users\Booba\RiderProjects\strings\strings\bin\Debug\net6.0\MatrixForRead.txt");
        MatrixPrinter(MatrixSum(oddMatrix1, oddMatrix2, length, length), length, length);
        TheMostPrimeNumberColumn(oddMatrix1, length, length);
    }

    public static int[,] MatrixGenerate(int length)
    {
        int[,] result = new int[length, length];
        return result;
    }

    public static int[,] OddMatrixFiller(int height, int width)
    {
        int[,] matrix = new int[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int e = 0; e < width; e++)
            {
                matrix[i, e] = OddNumberGenerator();
            }
        }

        return matrix;
    }

    public static void MatrixWrite(int[,] matrix, int length)
    {
        StreamWriter writer = new StreamWriter("Matrix.txt");
        for (int i = 0; i < length; i++)
        {
            string row = "";
            for (int e = 0; e < length; e++)
            {
                row += matrix[i, e] + " ";
            }
            writer.WriteLine(row);
        }

        writer.Close();
    }

    public static int[,] MatrixRead(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            var size = reader.ReadLine().Split(' ');
            int height = int.Parse(size[0]);
            int width = int.Parse(size[1]);

            int[,] matrix = new int[height, width];

            for (int i = 0; i < height; i++)
            {
                var row = reader.ReadLine().Split(' ');
                for (int e = 0; e < width; e++)
                {
                    matrix[i, e] = int.Parse(row[e]);
                }
            }

            return matrix;
        }
    }

    public static void MatrixPrinter(int[,] matrix, int height, int width)
    {
        for (int i = 0; i < height; i++)
        {
            string row = "";
            for (int e = 0; e < width; e++)
            {
                row += matrix[i, e] + " ";
            }
            Console.WriteLine(row);
        }
    }

    public static int OddNumberGenerator()
    {
        Random random = new Random();
        while (true)
        {
            int a = random.Next(-100, 101);
            if (a % 2 != 0)
            {
                return a;
            }
        }
    }

    public static int[,] MatrixSum(int[,] matrix1, int[,] matrix2, int height, int width)
    {
        var resultMatrix = new int[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int e = 0; e < width; e++)
            {
                resultMatrix[i, e] = matrix1[i, e] + matrix2[i, e];
            }
        }

        return resultMatrix;
    }

    public static void TheMostPrimeNumberColumn(int[,] matrix, int height, int width)
    {
        int counter = 0;
        int columnNumber = 0;
        for (int i = 0; i < height; i++)
        {
            int max = -1000;
            counter = 0;
            for (int e = 0; e < width; e++)
            {
                if (IsPrimeNumber(matrix[e, i]))
                {
                    counter++;
                } 
            }

            if (counter > max)
            {
                max = counter;
                columnNumber = i;
            }
        }

        for (int i = 0; i < height; i++)
        {
            Console.WriteLine(matrix[i, columnNumber]);
        }
    }

    public static bool IsPrimeNumber(int number)
    {
        int counter = 0;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                counter++;
            }
        }

        if (counter == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}