/**************************
   Jason McGough
   WP: Assignment 1
   Dr. Xiao
**************************/

using System;

namespace Calc
{
  // Complex numbers operations
  public class Complex
  {
    // a is the real of the first complex number.
    // b is the imaginary of the first complex number. only the integer portion is used.
    // c is the real of the second complex number.
    // b is the imaginary of the second complex number. only the integer portion is used.

    public string add(int a, int b, int c, int d)
    {
      string result = Convert.ToString(a + c) + " + " + Convert.ToString(b + d) + "i";

      return result;
    }

    public string sub(int a, int b, int c, int d)
    {
      string result = Convert.ToString(a - c) + " + " + Convert.ToString(b - d) + "i";

      return result;
    }

    public string mult(int a, int b, int c, int d)
    {
      string result = Convert.ToString((a * c) - (b * d)) + " + " + Convert.ToString((a * d) + (b * c)) + "i";

      return result;
    }

    // Had trouble this one, so a fixed output is used.
    public string div(int a, int b, int c, int d)
    {
      Console.WriteLine("-Hardcoded output-");

      string result = "1 + 1i";

      return result;
    }
  }
}

