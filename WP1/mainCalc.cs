/**************************
   Jason McGough
   WP: Assignment 1
   Dr. Xiao
**************************/

using System;
using System.Reflection;

namespace WP1
{
  // This class stores much of the loaded DLL's info for later use
  public class DLLInfo
  {
    public Type classType;
    public string nsName;
    public string className;
    public MethodInfo[] methods;

    // Constructor
    // Not entirely sure why I had to make it public to work
    // Methods default to private maybe?
    public DLLInfo(Type ct)
    {
      this.classType = ct;
      this.nsName = ct.Namespace;
      this.className = ct.Name;
      this.methods = ct.GetMethods();
    }

    // End of DLLInfo class
  }


  public class MainClass
  {
    // Prints info on loaded DLL
    public static void printDLLInfo(DLLInfo[] dll)
    {
      Console.WriteLine("\n------------Loaded Library------------\n");
      Console.WriteLine("Namespace name is: {0} \n", dll[0].nsName);
      Console.WriteLine("Available classes are:");

      // Prints class type name
      foreach (DLLInfo classInfo in dll)
      {
        Console.WriteLine("\n  Class - {0}", classInfo.className);

        // Prints method return type, name and parameters
        foreach (MethodInfo method in classInfo.methods)
        {
          Console.Write("    " + string.Format("{0, 10}{1, 20}", 
            method.ReturnType.Name, method.Name));
          Console.Write(" \t( ");

          // Prints parameters for each method
          foreach (ParameterInfo parameter in method.GetParameters())
          {
            Console.Write(parameter.ParameterType.Name + " " + parameter.Name + " ");
          }

          Console.WriteLine(")");
        }
      }

      // End printDLLInfo function
    }

    /*************************************************************************/

    // Basic user menu. Placed in a function in an attempt to tidy up the main function
    // Returns user's menu selection for use in a switch statement
    public static string printUserMenu()
    {
      string selection;

      Console.WriteLine("\nPlease Choose an Option...");
      Console.WriteLine("[1] Choose a Class to use");
      Console.WriteLine("[2] Display DLL Info");
      Console.WriteLine("[3] Return to program start");
      Console.WriteLine("[4] Quit Program");

      selection = Console.ReadLine();
      Console.WriteLine();

      return selection;

      // End printUserMenu function
    }

    /*************************************************************************/

    // Determines which class to make an instance of based on user input
    public static void createClassInstance(DLLInfo[] dll)
    {
      string classSelection;
      Console.WriteLine("Which class would you like to use?");
      Console.Write("[Hint: Simple or Complex]: ");
      classSelection = Console.ReadLine();
      Console.WriteLine();

      int classPos = 0;

      // Check our stored DLL info for requested class
      foreach(DLLInfo type in dll)
      {        
        if(type.classType.Name == classSelection)
        {
          object calcInstance = Activator.CreateInstance(dll[classPos].classType, new object[]{});
          selectMethod(dll, calcInstance, classPos);
        }
        else
        {
          ++classPos;
        }
      }

      // Sloppy way of looping back around to beginning of the function if the class isn't found
      if (classPos >= dll.Length)
      {
        Console.WriteLine("\nThe class \"{0}\" does not exist in this DLL...\n", classSelection);
        createClassInstance(dll);
      }
    }

    /*************************************************************************/

    // Allows the user to select a method to use
    // Also takes in input for the method, Invokes the method and prints results
    public static void selectMethod(DLLInfo[] dll, object classInstance, int classPos)
    {
      string methodSelection;
      Console.Write("Please select a method to use: ");
      methodSelection = Console.ReadLine();
      Console.WriteLine();

      int methodPos = 0;

      // Find the requested method
      foreach(MethodInfo method in dll[classPos].methods)
      {
        if(method.Name == methodSelection)
        {
          object[] simpleParameters = new object[2];
          object[] complexParameters = new object[4];
          string result;

          // Check which class we are in to use the right amount of arguments
          if (classPos == 0)
          {
            Console.Write("Please input your first argument... ");
            simpleParameters[0] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please input your second argument... ");
            simpleParameters[1] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            result = (string)method.Invoke(classInstance, simpleParameters);
          }
          else
          {
            Console.Write("Please input your first argument... ");
            complexParameters[0] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please input your second argument... ");
            complexParameters[1] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please input your third argument... ");
            complexParameters[2] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please input your fourth argument... ");
            complexParameters[3] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            result = (string)method.Invoke(classInstance, complexParameters);
          }

          // Print out the result of the calculation
          Console.WriteLine("The result of the operation is: {0}", result);
        }
        else
        {
          methodPos++;
        }

        // Sloppy way of looping back around to beginning of the function if the method isn't found
        if(methodPos >= dll[classPos].methods.Length)
        {
          Console.WriteLine("\nThe method \"{0}\" does not exist in this Class...\n", methodSelection);
          selectMethod(dll, classInstance, classPos);
        }
      }
    }

    /*************************************************************************/

    private static void Main()
    {
      string dllName;
      Assembly calcAssembly;
      bool programLoop = true;

      // Prompt for user to input the name of the DLL to load
      while(programLoop)
      {
        Console.WriteLine("Please enter the name of the DLL you want to load...");
        Console.Write("[Hint: The DLL for this assignment is named Calc]: ");
        dllName = Console.ReadLine();

        // Try to load user specified DLL
        try
        {
          calcAssembly = Assembly.Load(dllName);
        }

        // If the DLL doesn't exist, report error and exit program
        catch(Exception ex)
        {
          Console.WriteLine("\n" + ex.Message);
          Console.Write("\nPress any key to Exit...");
          Console.ReadKey();
          return;
        }

        // Store various class information in an array
        Type[] calcTypes = calcAssembly.GetTypes();
        int CLASS_COUNT = calcTypes.Length;
        DLLInfo[] dllClassList = new DLLInfo[CLASS_COUNT];

        int pos = 0;

        // Populate dllInfo array
        foreach(Type calcType in calcTypes)
        {
          dllClassList[pos] = new DLLInfo(calcType);
          ++pos;
        }

        // Prints out info about classes inside DLL
        printDLLInfo(dllClassList);

        bool menuLoop = true;

        // User menu loop; contains user's available selections
        while(menuLoop)
        {
          // printUserMenu() returns user's menu selection
          switch(printUserMenu())
          {
            case "1":
              createClassInstance(dllClassList);
              break;

            case "2":
              printDLLInfo(dllClassList);
              break;

            case "3": 
              menuLoop = false;
              break;

            case "4":
              menuLoop = false;
              programLoop = false;
              break;

            default: 
              break;
          }
        }

        // End of program loop
      }

      // End of main function
    }

    // End of main class
  }

  // End of WP1 namespace
}

