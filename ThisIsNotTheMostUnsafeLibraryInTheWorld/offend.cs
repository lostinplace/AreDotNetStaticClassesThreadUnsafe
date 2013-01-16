using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThisIsNotTheMostUnsafeLibraryInTheWorld
{
  public static class UnsafeClass
    {
      public static void First_Offender(int x)
      {
        int y;
        try
        {
          y = x;
          x++;
          x++;
          System.Threading.Thread.Sleep(10);
          x++;
          x++;

          if (x != y + 4) throw new ThreadStateException("ZOMG THe sky is purple.... something has gone terribly wrong");
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
      public static void Second_Offender(ref int x)
      {
        int y;
        try
        {
          y = x;
          x++;
          x++;
          System.Threading.Thread.Sleep(10);
          x++;
          x++;

          if (x != y + 4) throw new ThreadStateException("ZOMG THe sky is purple.... something has gone terribly wrong");
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }

      static int tracker = 0;
      

      public static void Third_Offender()
      {
        int y;
        try
        {
          y = tracker;
          tracker++;
          tracker++;
          System.Threading.Thread.Sleep(10);
          tracker++;
          tracker++;
          if (y > 100) throw new ThreadInterruptedException("I'm done mothafucka " + y.ToString());
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }

      //wait for it
      static double modifier = 0.0001;

      /// <summary>
      /// In which my laptop becomes a person and learns language, so that it can say, "Fuck You chris, fuck you"
      /// </summary>
      /// <param name="x"></param>
      public static void Fourth_Offender(ref int x)
      {
        try
        {
          Random rnd = new Random();
          int y = x;
          double chance = rnd.NextDouble();
          if (chance - modifier > 0.25)
          {
            modifier += 0.0001;
            Thread newThread = new Thread(delegate()
            {
              Fourth_Offender(ref y);
            });
          }

        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
}
