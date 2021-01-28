using System;
using System.Collections.Generic;

namespace PV178.Homeworks.HW03.Utils
{
	public class ToneCollection<T>
	{
		public Dictionary<char, Tuple<T, int>> Tones { get; set; } = new Dictionary<char, Tuple<T, int>>();

		public void AddRange(Dictionary<char, Tuple<T, int>> collection)
		{
			foreach (var tone in collection)
			{
				Tones.Add(tone.Key, tone.Value);
			}
		}

		public Tuple<T, int> GetInfo(char key)
		{
			return Tones[key];
		}
	}
}
