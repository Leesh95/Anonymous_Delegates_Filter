public class Program
{
    public delegate bool Filtering(int num);
    public static void Main()
    {
        int[] array = new int[] { 1, 2, 3, 5, 6, 11, 12, 13, 14, 22, 23, 33, 44, 55 };
        int[] evenArray = GetFiltered(array, delegate (int num) { return (num % 2 == 0); });
        int[] notEvenArray = GetFiltered(array, delegate (int num) { return !(num % 2 == 0); });
        int[] has3Array = GetFiltered(array, delegate (int num) { string numStr = num.ToString(); if (numStr.Contains("3")) return true; return false; });
        int[] hasSameNumberArray = GetFiltered(array, delegate (int num)
        {
            string numStr = num.ToString();
            if (numStr.Length == 1)
                return true;
            else
                for (int i = 0; i < numStr.Length - 1; i++)
                {
                    if (!(numStr[i] == numStr[i + 1]))
                        return false;
                }
            return true;
        });

        Console.WriteLine("Original array items: ");
        Print(array);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Even array items:");
        Print(evenArray);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Not even array items:");
        Print(notEvenArray);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Has 3 array items:");
        Print(has3Array);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Has same number array items:");
        Print(hasSameNumberArray);
        System.Console.WriteLine("\n********************");

    }
    //
    public static void Print(int[] array)
    {
        foreach (int num in array)
        {
            System.Console.Write($"{num}, ");
        }
    }
    //
    public static int[] GetFiltered(int[] array, Filtering filter)
    {
        int[] arr = new int[0];
        foreach (int num in array)
        {
            if (filter(num))
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[(arr.Length) - 1] = num;
            }
        }
        return arr;
    }
}
