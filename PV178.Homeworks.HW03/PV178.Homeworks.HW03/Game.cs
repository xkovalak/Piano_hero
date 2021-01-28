using PV178.Homeworks.HW03.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace PV178.Homeworks.HW03
{
	public class Game : IGame
	{
		private int _score;

		private readonly List<Func<int, int, bool>> _vipConditions = new List<Func<int, int, bool>>
		{
			{ (x, y) => x % 3 == 0 && y % 5 != 0 },
			{ (x, y) => x % 3 != 0 && y % 5 == 0 },
			{ (x, y) => (x + y) % 7 == 0 }
		};

		public void Run()
		{
			Console.WriteLine("Welcome to FIano Hero.");
			var vip = HasVip();
			Console.WriteLine("List of songs:");
			PrintSongs();
			Console.Write("Choose song: ");
			var song = Console.ReadLine();

			Reader reader;
			try
			{
				reader = new Reader(song, vip);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e);
				return;
			}
			

			_score = reader.Text.Length;

			reader.KeyPressed += OnKeyPressed;
			reader.KeyNotPressed += OnKeyNotPressed;

			reader.ReadKeys();
			reader.Dispose();

			Console.WriteLine("Your score: " + _score + "/" + reader.Text.Length);

			reader.KeyPressed -= OnKeyPressed;
			reader.KeyNotPressed -= OnKeyNotPressed;
		}

		public void OnKeyPressed(object source, PressKeyEventArgs args)
		{
			if (args.PressedKey != args.ActualKey)
			{
				_score--;
			}
		}

		public void OnKeyNotPressed(object source, PressKeyEventArgs args)
		{
			if (args.ActualKey != ' ')
			{
				_score--;
			}
		}

		public void PrintSongs()
		{
			var dir = new DirectoryInfo($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Songs{Path.DirectorySeparatorChar}");
			var files = dir.GetFiles("*.txt");
			foreach (var file in files)
			{
				Console.WriteLine(" -" + file.Name.Substring(0, file.Name.LastIndexOf('.')));
			}
		}

		private bool HasVip()
		{
			Console.Write("Do you have VIP code? (y/n):");
			if (!InputYn())
			{
				return false;
			}

			Console.Write("Write your code:");
			var code = Console.ReadLine();
			while (!code.IsCodeValid(_vipConditions))
			{
				Console.Write("Your code is invalid. Do you wish to input your code again? (y/n):");
				if (!InputYn())
				{
					return false;
				}

				Console.Write("Your code: ");
				code = Console.ReadLine();
			}

			return true;
		}

		private static bool InputYn()
		{
			var input2 = Console.ReadLine();
			while (input2 != "y")
			{
				if (input2 == "n")
				{
					return false;
				}

				Console.WriteLine("Invalid input. Try again.");
				Console.WriteLine("(y/n):");
				input2 = Console.ReadLine();
			}

			return true;
		}
	}
}