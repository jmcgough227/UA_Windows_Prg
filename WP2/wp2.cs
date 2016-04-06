/**************************************
* Jason McGough
* WP: Assignment 2
* Dr. Xiao
**************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winsh
{
  class Program
  {
    public static void displayPrompt()
    {
      Console.WriteLine("winsh>");
      Console.GetKey();
    }
    
    static void main(string[] args)
    {
      displayPrompt();
    }
  }
}