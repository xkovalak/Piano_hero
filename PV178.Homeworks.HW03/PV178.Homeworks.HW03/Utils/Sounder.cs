using System;
using System.IO;
using System.Media;
using System.Threading;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Class for making sound in other thread.
    /// </summary>
    public static class Sounder
    {
	    private static readonly string Path = $"..{System.IO.Path.DirectorySeparatorChar}..{System.IO.Path.DirectorySeparatorChar}.." +
	                                          $"{System.IO.Path.DirectorySeparatorChar}..{System.IO.Path.DirectorySeparatorChar}" +
	                                          $"Sounds{System.IO.Path.DirectorySeparatorChar}piano-";

	    /// <summary>
		/// Makes sound with given frequency and duration.
		/// </summary>
		/// <param name="frequency">frequency</param>
		/// <param name="duration">duration</param>
		public static void MakeSound(int frequency, int duration = 300)
        {
            ThreadPool.QueueUserWorkItem(state =>
                Console.Beep(frequency, duration));
        }

        public static void MakeCoolSound(char key)
        {
	        var player = new SoundPlayer(Path + key + ".wav");
            player.Play();
            player.LoadAsync();
            player.Dispose();
        }
    }
}
