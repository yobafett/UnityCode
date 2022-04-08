﻿using System;

static class RandomExtensions
{
    public static void Shuffle<T> (this Random rng, T[] array)
    {
        var n = array.Length;
        while (n > 1) 
        {
            var k = rng.Next(n--);
            (array[n], array[k]) = (array[k], array[n]);
        }
    }
}