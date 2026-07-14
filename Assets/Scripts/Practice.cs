 using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Practice : MonoBehaviour
{
    //-----Bobulle sort method ----------
    public int[] values = { 5, 1, 4, 2, 3 };
    public String[] names = { "m", "f", "g", "b", "a" };
    void Start()
    {
        //SorttheValues();
        //ArraryReverseFun();
        //FindSecondLorgestNumber();
        //RightOrderCheck(values2);
        //FindtheDuplicateNumbers();
        //MissingNumberFind();
        ZeroMoveFun();
    }
    private void SorttheValues()
    {
        for (int i = 0; i < values.Length - 1; i++)
        {
            for (int j = 0; j < values.Length - 1 - i; j++)
            {
                if (values[j] > values[j + 1])
                {
                    int temp = values[j];
                    values[j] = values[j + 1];
                    values[j + 1] = temp;
                    string temps = names[j];
                    names[j] = names[j + 1];
                    names[j + 1] = temps;
                }
            }
        }

        foreach (var value in values)
        {
            Debug.Log(value);
        }
    }
    //--------------Array Revrerse----------
    public int[] reversearray = { 1, 2, 3, 4, 5 };
    public void ArraryReverseFun()
    {
        for (int o = reversearray.Length - 1; o >= 0; o--)
        {
            Debug.Log(reversearray[o]);
        }
    }
    public void ArrayReverseFun()
    {
        int start = 0;
        int end = reversearray.Length - 1;

        while (start < end)
        {
            int temp = reversearray[start];
            reversearray[start] = reversearray[end];
            reversearray[end] = temp;

            start++;
            end--;
        }

        foreach (var value in reversearray)
        {
            Debug.Log(value);
        }
    }
    //-----------Second Lorgest Number--------------
    public int[] secondlorger = { 8, 3, 12, 5, 7, 10 };

    public void FindSecondLorgestNumber()
    {
        for (int p = 0; p < secondlorger.Length - 1; p++)
        {
            for (int a = 0; a < secondlorger.Length - 1 - p; a++)
            {
                if (secondlorger[a] > secondlorger[a + 1])
                {
                    int temp = secondlorger[a + 1];
                    secondlorger[a + 1] = secondlorger[a];
                    secondlorger[a] = temp;
                }
            }
        }
        Debug.Log(secondlorger[secondlorger.Length - 2]);
    }
    // Find the Right Assending Order--------------
    private int[] values1 = { 1, 2, 3, 4, 5 };
    private int[] values2 = { 1, 5, 3, 4, 2 };

    public void RightOrderCheck(int[] valuescheck)
    {
        bool itsRight = true;
        int a = valuescheck[0];
        int b = 0;
        while (itsRight)
        {
            int c = valuescheck[b];
            if (a != c)
            {
                itsRight = false;
                break;
            }
            a++;
            b++;
            if (valuescheck.Length == b)
            {
                break;
            }
        }
        if (itsRight)
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log("False");
        }
    }
    public void RightOrderCheckNew(int[] valuescheck)
    {
        bool isSorted = true;

        for (int i = 0; i < valuescheck.Length - 1; i++)
        {
            if (valuescheck[i] > valuescheck[i + 1])
            {
                isSorted = false;
                break;
            }
        }

        Debug.Log(isSorted);
    }
    //Find the Duplicate numbers without using list and hashsets others 
    private int[] numbers = { 2, 5, 7, 2, 9, 5, 1 };
    private List<int> RepetedNumbers = new();
    public void FindtheDuplicateNumbers()
    {
        int n = numbers.Length -1 ;
        int count = 0;
        while(count<n)
        {
            checklist(numbers[count]);
            count++;
        }
        foreach(var valu in RepetedNumbers)
        {
            Debug.Log("------"+valu);
        }
    }
    private void checklist(int value)
    {
        int temp = 0;
        for(int m = 0;m<numbers.Length;m++)
        {
            if(value == numbers[m])
            {
                temp ++;
            }
        }
        if(temp>=2)
        {
            RepetedNumbers.Add(value);
        }
    }
    // Find the missing number in the array
    private int[] Missingarrays = { 1, 2, 3, 5, 6 };
    private int MissingNumber = 0;
    private void MissingNumberFind()
    {
        int startvalue = Missingarrays[0];
        int tempvalue = startvalue;
        for(int m = 0;m<Missingarrays.Length - 1;m++)
        {
            if(Missingarrays[m] != tempvalue)
            {
                MissingNumber = tempvalue;
                break;
            }
            tempvalue ++;
        }
        Debug.Log(MissingNumber);
    }
    // Move to the zero in lost of the array 
    public int[] ZeroMover = { 5, 0, 2, 0, 8, 1, 0 };
    private void ZeroMoveFun()
    {
        
        foreach(int c in ZeroMover)
        {
            Debug.Log(c);
        }
    }
}
