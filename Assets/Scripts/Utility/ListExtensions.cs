using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ListExtensions
{
	public static void Shuffle<T>(this IList<T> items)
	{
		System.Random rand = new System.Random();
		for (int i = items.Count - 1; i > 0; i--)
		{
			int j = rand.Next(i + 1); // Returns a non-negative random integer that is less than the specified maximum - MSDN

			T temp = items[i];
			items[i] = items[j];
			items[j] = temp;
		}
	}
}
