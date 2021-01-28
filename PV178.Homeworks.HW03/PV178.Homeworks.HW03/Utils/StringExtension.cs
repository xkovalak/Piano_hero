using System;
using System.Collections.Generic;

namespace PV178.Homeworks.HW03.Utils
{
	public static class StringExtension
	{
		public static bool IsCodeValid(this string code, List<Func<int, int, bool>> conditions)
		{
			var xy = code.Split('I');
			if (xy.Length != 2 || xy[0].StartsWith("0") || xy[1].StartsWith("0"))
			{
				return false;
			}

			if (!int.TryParse(xy[0], out int x))
			{
				return false;
			}

			if (!int.TryParse(xy[1], out int y))
			{
				return false;
			}

			foreach (var condition in conditions)
			{
				if (condition(x, y))
				{
					return true;
				}
			}

			return false;
		}
	}
}
