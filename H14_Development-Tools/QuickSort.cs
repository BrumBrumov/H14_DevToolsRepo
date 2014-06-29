using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

class QuickSort
{
    static void Main()
    {
        List<string> list = new List<string>();
        Console.WriteLine("Enter the members of the array to be sorted.\nEnter \"quit\" to stop non integer value to stop.");
        string input = "";
        while ((input = Console.ReadLine())!= "quit")
        {
            list.Add(input);
        }
        string[] array = list.ToArray();
        array = new string[] {"ja", "what?", "haha", "meh", "haha", "abracadabra", "hello", "haha", "whatever"};

        list.Clear();
        list.TrimExcess();

        QSort(array, 0, array.Length - 1);
        Console.WriteLine(string.Join(" ", array));
    }
    //I am using eqL and eqR to more quickly handle the cases of arrays with multiple equal elements.
    static void QSort (string[] arr, int left, int right)
    {
        if (right <= left) return;
        int l = left - 1,
            r = right,
            eqL = left,
            eqR = right - 1;
        string pivot = arr[right];

        for (; ; )
        {
            while (arr[++l].CompareTo(pivot) < 0) ;
            while (arr[--r].CompareTo(pivot) > 0) if (r == l) break;
            if (l >= r) break;//If the left iteration has passed the right just leave the loop
            swap(ref arr[l], ref arr[r]);//Swap the respective numbers.
            if (arr[l] == pivot)//Check if either number is equal to the pivot, if so, move it to the leftmost or rightmost position in the array.
            {
                swap(ref arr[eqL], ref arr[l]);
                eqL++;
            }
            if (arr[r] == pivot)
            {
                swap(ref arr[eqR], ref arr[r]);
                eqR--;
            }
        }
        swap(ref arr[l], ref arr[right]);//Move the pivot to its sorted position.
        r = l - 1;
        l++;
        //Move the members equal to the pivot next to it.
        for (int i = left; i < eqL; i++, r--) swap(ref arr[i],ref arr[r]);
        for (int i = right - 1; i > eqR; i--, l++) swap(ref arr[i], ref  arr[l]);

        QSort(arr, left, r); //sort the subarray left of the pivot.
        QSort(arr, l, right); //sort the array right of the pivot
    }

    static void swap(ref string a, ref string b)
    {
        string temp = a;
        a = b;
        b = temp;
    }
}

