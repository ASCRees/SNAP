using System;

namespace NewGame.Snap
{
    /// <summary>
    /// Program
    /// Main program run by the console app
    /// </summary>
    /// <remarks>
    /// </remarks>
    internal class Program
    {
        // Main program executed when the console application runs
        /// <summary>
        /// Main program executed when the console application runs
        /// </summary>
        /// <returns>
        ///string of args
        /// </returns>
        private static void Main(string[] args)
        {
            try
            {
                PlaySnap pSnap = new PlaySnap();
                pSnap.PlayGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The program ran into an unexpected error. Please contact support for help. " + ex.Message);
            }
        }
    }
}