
Random r = new Random();

//массив
MyArray mas = new MyArray(6, 5);
for (int i = 0; i < 6; i++)
    for (int j = 0; j < 5; j++) mas.InitializationElement(i, j, r.Next(1, 10));
Console.WriteLine($"Изначальный массив:\n{mas.ToString()}");

mas.AddEndElementLine(2, 5);
Console.WriteLine($"Добавили в конец новую строку с 5 в индексе 2:\n{mas.ToString()}");

mas.AddEndElementColumn(3, 7);
Console.WriteLine($"Добавили в конец новую колонку с 7 в индексе 3:\n{mas.ToString()}");

mas.AddBeginElementLine(1, 4);
Console.WriteLine($"Добавили в начало новую строку с 4 в индексе 1:\n{mas.ToString()}");

mas.AddBeginElementColumn(4, 6);
Console.WriteLine($"Добавили в начало новую колонку с 6 в индексе 4:\n{mas.ToString()}");

mas.AddNewElement(3, 3, 1);
Console.WriteLine($"Добавили новый элемент mas[3,3] = 1:\n{mas.ToString()}");

mas.DeleteEndElementLine();
Console.WriteLine($"Удалили последнюю строку:\n{mas.ToString()}");

mas.DeleteEndElementColumn();
Console.WriteLine($"Удалили последнюю колонку:\n{mas.ToString()}");

mas.DeleteBeginElementLine();
Console.WriteLine($"Удалили первую строку:\n{mas.ToString()}");

mas.DeleteBeginElementColumn();
Console.WriteLine($"Удалили первую колонку:\n{mas.ToString()}");

mas.DeleteElement(2, 2);
Console.WriteLine($"Удалили элемент mas[3,3]:\n{mas.ToString()}");

MyArray mas2 = new MyArray(6, 6);
for (int i = 0; i < 6; i++)
    for (int j = 0; j < 6; j++) mas2.InitializationElement(i, j, r.Next(1, 10));
Console.WriteLine($"Изначальный массив:\n{mas2.ToString()}");
mas2.MainDiagonal1();
Console.WriteLine($"Заменили все элементы главной диагонали на 1:\n{mas2.ToString()}");

MyArray mas3 = new MyArray(6, 6);
for (int i = 0; i < 6; i++)
    for (int j = 0; j < 6; j++) mas3.InitializationElement(i, j, r.Next(-10, 10));
Console.WriteLine($"Изначальный массив:\n{mas3.ToString()}");
mas3.Negative0Positive1();
Console.WriteLine($"Заменили отрицательные элементы матрицы на 0, а положительные элементы - на 1:\n{mas3.ToString()}");

MyArray mas4 = new MyArray(6, 6);
for (int i = 0; i < 6; i++)
    for (int j = 0; j < 6; j++) mas4.InitializationElement(i, j, r.Next(1, 10));
Console.WriteLine($"Изначальный массив:\n{mas4.ToString()}");
mas4.MainDiagonal10();
Console.WriteLine($"Заменили все элементы главной диагонали на 1, остальные - на 0:\n{mas4.ToString()}");

//матрицы

MyMatrix mat = new MyMatrix(6, 6);
for (int i = 0; i < 6; i++)
    for (int j = 0; j < 6; j++) mat.InitializationElement(i, j, r.Next(-9, 10));
Console.WriteLine($"\n\nИзначальная матрица:\n{mat.ToString()}");

Console.WriteLine($"Сумма элементов главной диагонали: {mat.GetSumOfMainDiagonal()}\n");

Console.WriteLine($"Среднее арифметическое элементов матрицы: {mat.GetArithmeticMean()}\n");

double[] col = mat.GetArithmeticMeanOfColumns();
Console.WriteLine($"Среднее арифметическое каждого из столбцов:");
for (int i = 0; i < col.Length; i++) Console.WriteLine($"{i} столбец: {col[i]}");

double[] col2 = mat.GetArithmeticMeanOfEvenColumns();
Console.WriteLine($"\nСреднее арифметическое каждого четного столбца:");
Console.WriteLine($"{0} столбец: {col2[0]}");
for (int i = 1; i < col2.Length; i++) Console.WriteLine($"{Math.Pow(2, i)} столбец: {col2[i]}");

Console.WriteLine($"\nМаксимальный элемент: {mat.GetMaxElement()}");

Console.WriteLine($"\nМинимальный элемент: {mat.GetMinElement()}");

Console.WriteLine($"\nСумма элементов 1-го столбца матрицы: {mat.GetSumOfFirstColumn()}");

Console.WriteLine($"\nСумма элементов строки, в которой расположен наименьший элемент матрицы: {mat.GetSumOfMinElementColumn()}");

Console.WriteLine($"\nЗначение наибольшего по модулю элемента матрицы: {mat.GetMaxModuleElement()}");

Console.WriteLine($"\nСумма наибольших значений элементов строк матрицы: {mat.GetSumOfMaxElementsOfLines()}");

Console.WriteLine($"\nНаибольшее из значений элементов 2 строки: {mat.GetMaxElementOfColumn(2)}");

Console.WriteLine($"\nЧисло отрицательных элементов в 3 строке: {mat.GetNumberOfNegativeElementsOfLine(3)}");

Console.WriteLine($"\nПроизведение всех элементов матрицы: {mat.GetProductOfElements()}");

Console.WriteLine($"\nПроизведение квадратов тех элементов 1 строки, которые больше 1, но меньше 3: {mat.GetProductOfElementsOfLine(1)}");

Console.WriteLine($"\nПроизведение модулей элементов 0 строки: {mat.GetProductOfModuleElementsOfLine(0)}");

class MyArray
{
    int x = 0;
    int y = 0;
    int[,] arr;
    public MyArray()
    {
        arr = new int[100, 100];
    }
    public MyArray(int i, int j)
    {   
        x = i;
        y = j;
        arr = new int[i, j];
    }
    public void InitializationElement(int i, int j, int value)
    {
        arr[i, j] = value;
    }
    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++) s = string.Concat(s, arr[i, j], "\t");
            s = string.Concat(s, "\n");
        }
        return s;
    }
    
    public void AddEndElementLine(int jnew, int value)
    {
        x++;
        int[,] arrnew = new int[x, y];
        for (int i = 0; i < x - 1; i++)
            for (int j = 0; j < y; j++) arrnew[i, j] = arr[i, j];
        arrnew[x - 1, jnew] = value;
        arr = arrnew;
    }
    public void AddEndElementColumn(int inew, int value)
    {
        y++;
        int[,] arrnew = new int[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y - 1; j++) arrnew[i, j] = arr[i, j];
        arrnew[inew, y - 1] = value;
        arr = arrnew;
    }
    public void AddBeginElementLine(int jnew, int value)
    {
        x++;
        int[,] arrnew = new int[x, y];
        for (int i = 1; i < x; i++)
            for (int j = 0; j < y; j++) arrnew[i, j] = arr[i - 1, j];
        arrnew[0, jnew] = value;
        arr = arrnew;
    }

    public void AddBeginElementColumn(int inew, int value)
    {
        y++;
        int[,] arrnew = new int[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 1; j < y; j++) arrnew[i, j] = arr[i, j - 1];
        arrnew[inew, 0] = value;
        arr = arrnew;
    }
    public void AddNewElement(int inew, int jnew, int value)
    {
        x++; y++;
        int[,] arrnew = new int[x, y];

        for (int i = 0; i < inew; i++)
            for (int j = 0; j < jnew; j++) arrnew[i, j] = arr[i, j];

        for (int i = 0; i < inew; i++)
            for (int j = jnew + 1; j < y; j++) arrnew[i, j] = arr[i, j - 1];

        for (int i = inew + 1; i < x - 1; i++)
            for (int j = 0; j < jnew; j++) arrnew[i, j] = arr[i - 1, j];

        for (int i = inew + 1; i < x; i++)
            for (int j = jnew + 1; j < y; j++) arrnew[i, j] = arr[i - 1, j - 1];

        arrnew[inew, jnew] = value;
        arr = arrnew;
    }
    public void DeleteEndElementLine()
    {
        x--;
        int[,] arrnew = new int[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++) arrnew[i, j] = arr[i, j];
        arr = arrnew;
    }
    public void DeleteEndElementColumn()
    {
        y--;
        int[,] arrnew = new int[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++) arrnew[i, j] = arr[i, j];
        arr = arrnew;
    }
    public void DeleteBeginElementLine()
    {
        x--;
        int[,] arrnew = new int[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++) arrnew[i, j] = arr[i + 1, j];
        arr = arrnew;
    }
    public void DeleteBeginElementColumn()
    {
        y--;
        int[,] arrnew = new int[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++) arrnew[i, j] = arr[i, j + 1];
        arr = arrnew;
    }
    public void DeleteElement(int idel, int jdel)
    {
        x--; y--;
        int[,] arrnew = new int[x, y];

        for (int i = 0; i < idel; i++)
            for (int j = 0; j < jdel; j++) arrnew[i, j] = arr[i, j];

        for (int i = idel; i < x; i++)
            for (int j = 0; j < jdel; j++) arrnew[i, j] = arr[i + 1, j];

        for (int i = 0; i < idel; i++)
            for (int j = jdel; j < y; j++) arrnew[i, j] = arr[i, j + 1];

        for (int i = idel; i < x; i++)
            for (int j = jdel; j < y; j++) arrnew[i, j] = arr[i + 1, j + 1];

        arr = arrnew;
    }
    public void MainDiagonal1()
    {
        for(int i = 0; i < x; i++)
            for(int j = 0; j < y; j++)
                if (i == j) arr[i, j] = 1;
    }
    public void Negative0Positive1()
    {
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
            {
                if (arr[i, j] > 0) arr[i, j] = 1;
                else arr[i, j] = 0;
            }    
    }
    public void MainDiagonal10()
    {
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
            {
                if (i == j) arr[i, j] = 1;
                else arr[i, j] = 0;
            }   
    }
}


class MyMatrix
{
    int n = 0;
    int m = 0;
    int[,] matrix;
    public MyMatrix()
    {
        matrix = new int[100, 100];
    }
    public MyMatrix(int i, int j)
    {
        n = i;
        m = j;
        matrix = new int[i, j];
    }
    public void InitializationElement(int i, int j, int value)
    {
        matrix[i, j] = value;
    }
    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++) s = string.Concat(s, matrix[i, j], "\t");
            s = string.Concat(s, "\n");
        }
        return s;
    }
    public int GetSumOfMainDiagonal()
    {
        int sum = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (i == j) sum += matrix[i, j];
        return sum;
    }
    public double GetArithmeticMean()
    {
        double am = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++) am += matrix[i, j];
        am /= matrix.Length;
        return am;
    }
    public double[] GetArithmeticMeanOfColumns()
    {
        double[] columns = new double[m];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++) columns[j] += matrix[i, j];

        for (int j = 0; j < m; j++) columns[j] /= n;

        return columns;
    }
    public double[] GetArithmeticMeanOfEvenColumns()
    {
        int j2;
        if (m % 2 == 1) j2 = (m / 2) + 1;
        else j2 = (m / 2);
        double[] columns = new double[j2];
        j2 = 0;

        for (int j = 0; j < m; j++)
            if (j % 2 == 0)
            {
                for (int i = 0; i < n; i++) columns[j2] += matrix[i, j];
                j2++;
            }
            

        for (int j = 0; j < j2; j++) columns[j] /= n;

        return columns;
    }
    public int GetMaxElement()
    {
        int max = matrix[0, 0];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++) 
                if (matrix[i, j] > max) max = matrix[i, j];
        return max;
    }
    public int GetMinElement()
    {
        int min = matrix[0, 0];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (matrix[i, j] < min) min = matrix[i, j];
        return min;
    }
    public int GetSumOfFirstColumn()
    {
        int sum = 0;
        int j = 0;
        for (int i = 0; i < n; i++) sum += matrix[i, j];
        return sum;
    }
    public int GetSumOfMinElementColumn()
    {
        int min = matrix[0, 0];
        int jmin = 0;
        int sum = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    jmin = j;
                }
        for (int i = 0; i < n; i++) sum += matrix[i, jmin];
        return sum;
    }
    public int GetMaxModuleElement()
    {
        int max = Math.Abs(matrix[0, 0]);
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (Math.Abs(matrix[i, j]) > Math.Abs(max)) max = matrix[i, j];
        return max;
    }
    public int GetSumOfMaxElementsOfLines()
    {
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            int max = matrix[i, 0];
            for (int j = 0; j < m; j++)
                if (matrix[i, j] > max) max = matrix[i, j];
            sum += max;
        }
        return sum;
    }
    public int GetMaxElementOfColumn(int i)
    {
        int max = matrix[i, 0];
        for (int j = 0; j < n; j++)
            if (matrix[i, j] > max) max = matrix[i, j];
        return max;
    }
    public int GetNumberOfNegativeElementsOfLine(int i)
    {
        int num = 0;
        for (int j = 0; j < n; j++)
            if (matrix[i, j] < 0) num++;
        return num;
    }
    public int GetProductOfElements()
    {
        int prod = 1;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++) prod *= matrix[i, j];
        return prod;
    }
    public double GetProductOfElementsOfLine(int i)
    {
        double prod = 1;
        int flag = 0;
        for (int j = 0; j < n; j++)
            if (matrix[i, j] > 1 && matrix[i, j] < 3)
            {
                flag = 1;
                prod *= Math.Pow(matrix[i, j], 2);
            }
        if (flag == 1) return prod;
        else return 0;
    }
    public double GetProductOfModuleElementsOfLine(int i)
    {
        double prod = 1;
        for (int j = 0; j < n; j++)
                prod *= Math.Abs(matrix[i, j]);
        return prod;
    }
}