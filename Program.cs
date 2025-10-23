//Task1();
//Task2();
//Task3();
//Task4();
//Task5();
//Task6();
Task7();

void Task1()
{
    double[] A = new double[5];
    double[,] B = new double[3, 4];

    Console.WriteLine("Enter 5 numbers for array A:");
    for (int i = 0; i < A.Length; i++)
    {
        Console.Write("A[" + i + "]: ");
        string? input = Console.ReadLine();
        A[i] = double.Parse(input);
    }

    Random rnd = new Random();
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            B[i, j] = Math.Round(rnd.NextDouble() * 100, 1);
        }
    }

    Console.WriteLine("\nArray A:");
    for (int i = 0; i < A.Length; i++)
    {
        Console.Write(A[i] + " ");
    }

    Console.WriteLine("\n\nArray B:");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Console.Write(B[i, j].ToString("F2") + "\t");
        }
        Console.WriteLine();
    }

    double max = A[0], min = A[0];
    double sum = 0;
    double product = 1;

    for (int i = 0; i < A.Length; i++)
    {
        double x = A[i];
        if (x > max) max = x;
        if (x < min) min = x;
        sum += x;
        product *= x;
    }

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            double x = B[i, j];
            if (x > max) max = x;
            if (x < min) min = x;
            sum += x;
            product *= x;
        }
    }

    double evenSumA = 0;
    for (int i = 0; i < A.Length; i++)
    {
        if (A[i] % 2 == 0)
            evenSumA += A[i];
    }

    double oddColumnSumB = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            if (j % 2 == 0)
                oddColumnSumB += B[i, j];
        }
    }

    Console.WriteLine("\n--- Results ---");
    Console.WriteLine("Max element: " + max);
    Console.WriteLine("Min element: " + min);
    Console.WriteLine("Total sum: " + sum.ToString("F2"));
    Console.WriteLine("Total product: " + product.ToString("F2"));
    Console.WriteLine("Sum of even elements in A: " + evenSumA);
    Console.WriteLine("Sum of odd columns in B: " + oddColumnSumB.ToString("F2"));
}

void Task2()
{
    int[,] arr = new int[5, 5];
    Random rnd = new Random();

    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            arr[i, j] = rnd.Next(-100, 100);
        }
    }

    Console.WriteLine("Array:");
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            Console.Write(arr[i, j].ToString().PadLeft(5));
        }
        Console.WriteLine();
    }

    int min = arr[0, 0], max = arr[0, 0];
    int minIndex = 0, maxIndex = 0;

    int index = 0;
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (arr[i, j] < min)
            {
                min = arr[i, j];
                minIndex = index;
            }
            if (arr[i, j] > max)
            {
                max = arr[i, j];
                maxIndex = index;
            }
            index++;
        }
    }

    int start = Math.Min(minIndex, maxIndex);
    int end = Math.Max(minIndex, maxIndex);
    int sum = 0;

    index = 0;
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (index > start && index < end)
            {
                sum += arr[i, j];
            }
            index++;
        }
    }

    Console.WriteLine($"\nMin element: {min}");
    Console.WriteLine($"Max element: {max}");
    Console.WriteLine($"Sum of elements between min and max: {sum}");
}

void Task3()
{
    Console.Write("Enter text: ");
    string? text = Console.ReadLine();

    Console.Write("Enter shift value (e.g. 3): ");
    string? shiftStr = Console.ReadLine();
    int shift = int.Parse(shiftStr);

    Console.Write("Choose action (1 - Encrypt, 2 - Decrypt): ");
    string? actionStr = Console.ReadLine();
    int action = int.Parse(actionStr);

    if (string.IsNullOrEmpty(text))
    {
        Console.WriteLine("Error: empty text.");
        return;
    }

    if (action == 2)
    {
        shift = 26 - (shift % 26);
    }

    string result = "";

    foreach (char c in text)
    {
        if (c >= 'A' && c <= 'Z')
        {
            char enc = (char)('A' + (c - 'A' + shift) % 26);
            result += enc;
        }
        else if (c >= 'a' && c <= 'z')
        {
            char enc = (char)('a' + (c - 'a' + shift) % 26);
            result += enc;
        }
        else
        {
            result += c;
        }
    }

    if (action == 1)
        Console.WriteLine("Encrypted text: " + result);
    else
        Console.WriteLine("Decrypted text: " + result);
}

void Task4()
{
    Console.Write("Enter number of rows: ");
    int rows = int.Parse(Console.ReadLine());

    Console.Write("Enter number of columns: ");
    int cols = int.Parse(Console.ReadLine());

    double[,] A = new double[rows, cols];
    double[,] B = new double[rows, cols];

    Console.WriteLine("\nEnter elements for matrix A:");
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write($"A[{i},{j}]: ");
            A[i, j] = double.Parse(Console.ReadLine());
        }
    }

    Console.WriteLine("\nEnter elements for matrix B:");
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write($"B[{i},{j}]: ");
            B[i, j] = double.Parse(Console.ReadLine());
        }
    }
    bool exit = true;
    while (exit)
    {
        Console.WriteLine("\nChoose operation:");
        Console.WriteLine("1 - Multiply matrix A by number");
        Console.WriteLine("2 - Add matrices A and B");
        Console.WriteLine("3 - Multiply matrices A and B");
        Console.WriteLine("4 - Exit");
        Console.Write("Your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter number: ");
                double k = double.Parse(Console.ReadLine());
                Console.WriteLine("\nResult (A * " + k + "):");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write((A[i, j] * k).ToString("F2") + "\t");
                    }
                    Console.WriteLine();
                }
                break;

            case 2:
                Console.WriteLine("\nResult (A + B):");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write((A[i, j] + B[i, j]).ToString("F2") + "\t");
                    }
                    Console.WriteLine();
                }
                break;

            case 3:
                if (cols != rows)
                {
                    Console.WriteLine("Error: matrices cannot be multiplied (columns of A must equal rows of B).");
                    return;
                }

                double[,] C = new double[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        C[i, j] = 0;
                        for (int k2 = 0; k2 < cols; k2++)
                        {
                            C[i, j] += A[i, k2] * B[k2, j];
                        }
                    }
                }

                Console.WriteLine("\nResult (A * B):");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(C[i, j].ToString("F2") + "\t");
                    }
                    Console.WriteLine();
                }
                break;

            case 4:
                exit = false;
                break;

            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}

void Task5()
{

    Console.Write("Enter your equation: ");
    string input = Console.ReadLine();

    input = input.Replace("-", "+-");

    string[] parts = input.Split('+', StringSplitOptions.RemoveEmptyEntries);

    int sum = 0;

    foreach (string part in parts)
    {
        sum += int.Parse(part);
    }

    Console.WriteLine("Result: " + sum);
}

void Task6()
{
    Console.Write("Enter your text: ");
    string input = Console.ReadLine();
    string[] parts = input.Split('.', StringSplitOptions.RemoveEmptyEntries);
    foreach (string part in parts)
    {
        string trimmed = part.Trim();
        if (trimmed.Length > 0)
        {
            string result = char.ToUpper(trimmed[0]) + trimmed.Substring(1).ToLower() + ". ";
            Console.Write(result);
        }
    }
}

void Task7()
{
    Console.WriteLine("Enter your text:");
    string input = Console.ReadLine();

    string[] badWords = { "die", "kill", "blood", "shit" };
    int replacements = 0;

    string[] parts = input.Split(' ');

    for (int i = 0; i < parts.Length; i++)
    {
        string trimmed = parts[i].Trim(new char[] { ',', '.', ';', ':', '!', '?' });

        foreach (string badWord in badWords)
        {
            if (trimmed.ToLower() == badWord.ToLower())
            {
                string censored = new string('*', badWord.Length);
                parts[i] = parts[i].Replace(trimmed, censored);
                replacements++;
            }
        }
    }

    string result = string.Join(" ", parts);

    Console.WriteLine("\nResult:");
    Console.WriteLine(result);
    Console.WriteLine($"\nStatistics: {replacements} replacements made.");
}

