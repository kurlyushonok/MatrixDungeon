using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using Random = System.Random;

public class MatrixGenerator
{
    public List<List<int>> GetMatrix(int minValue, int maxValue, int rowCnt, int columnCnt)
    {
        if (rowCnt <= 0 || columnCnt <= 0) throw new InvalidOperationException();
        var rnd = new Random();
        var matrix = new List<List<int>>();
        for (int i = 0; i < rowCnt; i++)
        {
            var row = new List<int>();
            for (int j = 0; j < columnCnt; j++)
                row.Add(rnd.Next(minValue, maxValue));
            matrix.Add(row);
        }

        return matrix;
    }
}
