namespace Lab3;
public class CompanyProject
{
    //================================ functions for task 1 =========================================
    private char[] stack = new char[30];
    private int top = -1;
    private int MAX = 30;
    private void Push(char[] array, int position)
    {
        //розміщення елементу в стеці
        if (top == MAX - 1)
            Console.WriteLine("\nstack overflow!\n");
        else
        {
            top++;
            stack[top] = array[position];
        }
    }
    private char Pop()
    {
        //повернення елементу зі стеку і його видалення
        char ch;
        if (top < 0)
        {
            Console.WriteLine("\nstack underflow!\n");
            return '0';
        }
        else
        {
            ch = stack[top];
            stack[top] = '\0'; //заміщення елемента в стеку нулем
            top--;
            return (ch);
        }
    }

    //================================ task 1 =========================================
    public void Brackets()
    {
        /*Увести з консолі рядок символів (тип string), що містить круглі, квадратні та фігурні дужки. Визначити чи є послідовність дужок правильною, 
          тобто кількість дужок, що відкривається, дорівнює кількості дужок, що закриваються. Результати вивести на консоль.*/
        Console.WriteLine("enter string: ");
        string str = Console.ReadLine() + '\0';
        char[] arr = str.ToCharArray(0, str.Length);
        bool flag = true;
        char tmp;

        int i = 0, j = i + 1;
        while (arr[i] != '\0' && flag == true) //допоки існує рядок
        {

            if (arr[i] == '(' || arr[i] == '{' || arr[i] == '[') //якщо знаходиться відкриваюча дужка
            {
                if (arr[i] == '(') //якщо відкриваюча дужка
                {
                    if (arr[j] == ')')
                    {
                        arr[i] = '\0';
                        arr[j] = '\0';
                        i += 2;
                        j += 2;
                    }
                    else
                    {
                        Push(arr, i);
                        arr[i] = '\0';
                        i++;
                        j++;
                    }
                }
                else if (arr[i] == '{') //якщо відкриваюча дужка
                {
                    if (arr[j] == '}')
                    {
                        arr[i] = '\0';
                        arr[j] = '\0';
                        i += 2;
                        j += 2;
                    }
                    else
                    {
                        Push(arr, i);
                        arr[i] = '\0';
                        i++;
                        j++;
                    }
                }
                else if (arr[i] == '[') //якщо відкриваюча дужка
                {
                    if (arr[j] == ']')
                    {
                        arr[i] = '\0';
                        arr[j] = '\0';
                        i += 2;
                        j += 2;
                    }
                    else
                    {
                        Push(arr, i);
                        arr[i] = '\0';
                        i++;
                        j++;
                    }
                }
            }
            else if (arr[i] == ')' || arr[i] == '}' || arr[i] == ']') //якщо знаходиться закриваюча дужка
            {
                if (arr[i] == ')') //якщо закриваюча дужка
                {
                    if (stack[top] == '(')
                    {
                        tmp = Pop();
                        arr[i] = '\0';
                        i++;
                        j++;
                    }
                    else
                        flag = false;
                }
                else if (arr[i] == '}') //якщо закриваюча дужка
                {
                    if (stack[top] == '{')
                    {
                        tmp = Pop();
                        arr[i] = '\0';
                        i++;
                        j++;
                    }
                    else
                        flag = false;
                }
                else if (arr[i] == ']') //якщо закриваюча дужка
                {
                    if (stack[top] == '[')
                    {
                        tmp = Pop();
                        arr[i] = '\0';
                        i++;
                        j++;
                    }
                    else
                        flag = false;
                }
            }
            else
            {
                arr[i] = '\0';
                i++;
                j++;
            }
        }
        if (flag)
            Console.WriteLine("correct");
        else
            Console.WriteLine("false");

    }


    //================================ functions for task 2 =========================================
    private int[,] MatrixInput(ushort isize, ushort jsize, int left, int right)
    {
        int[,] Matrix = new int[isize, jsize];
        Random ArrRand = new Random();
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                Matrix[i, j] = ArrRand.Next(left, right);
            }
        }
        return Matrix;
    }
    private void MatrixOutput(int[,] Matrix)
    {
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                Console.Write(Matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    //================================ task 2 =========================================
    public void Matrix()
    {
        /*Згенерувати елементи матриці, задавши її вимірність та діапазон значень з консолі. На перетині i-го рядка та j-го стовпчика матриці 
          записаний прибуток за j-й місяць від продажу i-го товару в магазині. Вивести матрицю на консоль. 
          Визначити загальний прибуток від кожного товару, загальний прибуток магазину від продажу усіх  товарів за усі місяці, індекс товару, 
          який приносить прибуток.Вивести результати на консоль.
          Вивести на консоль значення мінімального та максимального елементів матриці та їх індекси, застосувавши методи класу Math.*/

        int left, right;
        int totalIncome = 0;
        ushort isize, jsize;
        Console.Write("enter number of rows: ");
        while (!UInt16.TryParse(Console.ReadLine(), out isize)) //перевірка на правильність вводу
        {
            Console.Write("wrong! enter number of rows: ");
        }

        Console.Write("enter number of columns: ");
        while (!UInt16.TryParse(Console.ReadLine(), out jsize)) //перевірка на правильність вводу
        {
            Console.Write("wrong! enter number of columns: ");
        }

        Console.WriteLine("\nenter the range of numbers: ");
        Console.Write("enter minimum (from 0): ");
        while (!Int32.TryParse(Console.ReadLine(), out left) || left < 0) //перевірка на правильність вводу
        {
            Console.Write("wrong! enter minimum (from 0): ");
        }
        Console.Write("enter maximum: ");
        while (!Int32.TryParse(Console.ReadLine(), out right)) //перевірка на правильність вводу
        {
            Console.Write("enter maximum: ");
        }
        Console.WriteLine();

        int[,] Matr = MatrixInput(isize, jsize, left, right);
        Console.WriteLine("goods(rows) and income(columns): ");
        MatrixOutput(Matr);

        int maxincome = 0, Imaxincome = 0, maxvalue = Matr[0, 0], minvalue = Matr[0, 0];
        int Imaximum = 0, Jmaximum = 0, Iminimum = 0, Jminimum = 0;
        for (int i = 0; i < Matr.GetLength(0); i++)
        {
            int income = 0;
            Console.Write($"for product with index {i} the income is: ");
            for (int j = 0; j < Matr.GetLength(1); j++)
            {
                income += Matr[i, j];
                maxvalue = Math.Max(maxvalue, Matr[i, j]);
                minvalue = Math.Min(minvalue, Matr[i, j]);
                if (maxvalue == Matr[i, j])
                {
                    Imaximum = i;
                    Jmaximum = j;
                }
                if (minvalue == Matr[i, j])
                {
                    Iminimum = i;
                    Jminimum = j;
                }
            }
            Console.WriteLine(income + "$");
            if (income > maxincome)
            {
                maxincome = income;
                Imaxincome = i;
                totalIncome += income;
            }
        }
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"total income is {totalIncome}$");
        Console.WriteLine($"most income is from {Imaxincome} product: {maxincome}$");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"maximum value is {maxvalue} with indexes [{Imaximum},{Jmaximum}]");
        Console.WriteLine($"minimum value is {minvalue} with indexes [{Iminimum},{Jminimum}]");
    }
}

