using System;
using System.Collections.Generic;

namespace PV178.Homeworks.HW03.Utils
{
	public class Piano
	{
		private readonly Dictionary<char, Tuple<char, int>> _tones = new Dictionary<char, Tuple<char, int>>
		{
			{ 'a', Tuple.Create('C', 261) },
			{ 's', Tuple.Create('D', 293) },
			{ 'd', Tuple.Create('E', 330) },
			{ 'f', Tuple.Create('F', 349) },
			{ 'g', Tuple.Create('G', 392) },
			{ 'h', Tuple.Create('A', 440) },
			{ 'j', Tuple.Create('H', 494) }
		};

		public ToneCollection<char> Tones { get; } = new ToneCollection<char>();

		public Piano()
		{
			Tones.AddRange(_tones);
		}
	}
}
