using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      
      try
      {
        paralleltest(delegate(){
          Random rnd = new Random();
          ThisIsNotTheMostUnsafeLibraryInTheWorld.UnsafeClass.First_Offender(Convert.ToInt32((rnd.NextDouble() * 10)));
        });
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
        throw ex;
      }
    }

    [TestMethod]
    public void TestMethod2()
    {
      
      try
      {
        paralleltest(delegate()
        {
          Random rnd = new Random();
          int x= Convert.ToInt32((rnd.NextDouble() * 10));
          ThisIsNotTheMostUnsafeLibraryInTheWorld.UnsafeClass.Second_Offender(ref x);
        });
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
        throw ex;
      }
    }

    [TestMethod]
    public void TestMethod3()
    {
      try
      {
        paralleltest(delegate()
        {
          try
          {
            ThisIsNotTheMostUnsafeLibraryInTheWorld.UnsafeClass.Third_Offender();
          }
          catch (Exception ex)
          {
            Assert.Fail();
            throw ex;
          }
          
        });
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
        throw ex;
      }
    }
    
    public static Task[] buildparalleltest(Action anAction)
    {
      List<Task> threadList = new List<Task>();
      
      
      for (int i = 0; i < 1000; i++)
      {
        threadList.Add(new Task(delegate()
        {
          anAction();
        }));
      }
      return threadList.ToArray();
    }

  }
}
