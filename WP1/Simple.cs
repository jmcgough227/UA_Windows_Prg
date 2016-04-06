/**************************
   Jason McGough
   WP: Assignment 1
   Dr. Xiao
**************************/

using System;

namespace Calc
{
  // Simple numbers calculator operations
  // Results are converted to strings to generalize output
  public class Simple
  {
    public string add(int a, int b)
    {
      int result = a + b;

      return Convert.ToString(result);
    }
    
    public string sub(int a, int b)
    {
      int result = a - b;

      return Convert.ToString(result);
    }
    
    public string mult(int a, int b)
    {
      int result = a * b;

      return Convert.ToString(result);
    }
    
    public string div(int a, int b)
    {
      int result = a / b;

      return Convert.ToString(result);
    }
  }
}

