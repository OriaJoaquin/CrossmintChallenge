using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossmintChallenge.Application.Helpers
{
    public static class ProgressBarHelper
    {
        public static void UpdateProgressBar(int currentStep, int totalSteps)
        {
            Console.CursorLeft = 0;
            Console.Write("[");

            int progressLength = 30;
            int progressBarIndex = (int)((double)currentStep / totalSteps * progressLength);

            for (int i = 0; i < progressLength; i++)
            {
                if (i < progressBarIndex)
                    Console.Write("=");
                else
                    Console.Write(" ");
            }

            Console.Write("] ");
            Console.Write($"{currentStep}/{totalSteps}");
        }
    }
}
