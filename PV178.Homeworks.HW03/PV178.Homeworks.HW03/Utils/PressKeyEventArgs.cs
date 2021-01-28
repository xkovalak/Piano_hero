using System;

namespace PV178.Homeworks.HW03.Utils
{
	public class PressKeyEventArgs : EventArgs
	{
		public char PressedKey { get; set; }
		public char ActualKey { get; set; }

		public PressKeyEventArgs(char pressedKey, char actualKey)
		{
			PressedKey = pressedKey;
			ActualKey = actualKey;
		}

		public PressKeyEventArgs(char actualKey)
		{
			ActualKey = actualKey;
		}
	}
}
