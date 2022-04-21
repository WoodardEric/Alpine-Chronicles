NPCs/Enemies
I will be creating and implementing NPCs and Enemies for the player to interact with and fight.
As Team Lead 5, my feature is to design and implement AI into our game. 
I have done this in the form of creating non-player characters as well as enemies for the player to fight. 
I have also made a partial demo mode for the game to “play itself” automatically.

Technical Static and Dynamic Binding:
// Example of how I would set the static type of Model_color using System;
 
class Vehicle {
     public static string Model_color = "Black";
}
 
// Driver Class
public class GFG {
 
    static public void Main()
    {
 
        // Accessing the static variable
        Console.WriteLine("Color of XY model is  : {0} ",
                                    Vehicle.Model_color);
    }
}

// Example of how I may set the dynamic type of a variable
using System;
  
class GFG {
  
    static public void Main()
    {
  
        // Dynamic variables
        dynamic value1 = "GusIsCool";
        dynamic value2 = 123234;
        dynamic value3 = 2132.55;
        dynamic value4 = false;
  
        // Get the actual type of 
        // dynamic variables
        // Using GetType() method
        Console.WriteLine("Get the actual type of value1: {0}",
                                  value1.GetType().ToString());
  
        Console.WriteLine("Get the actual type of value2: {0}",
                                  value2.GetType().ToString());
  
        Console.WriteLine("Get the actual type of value3: {0}",
                                  value3.GetType().ToString());
  
        Console.WriteLine("Get the actual type of value4: {0}", 
                                  value4.GetType().ToString());
    }
}
// Output should look like this
Get the actual type of value1: System.String
Get the actual type of value2: System.Int32
Get the actual type of value3: System.Double
Get the actual type of value4: System.Boolean

Patterns:
Justification for using Template pattern: 
I mainly wanted to avoid duplication in the code, the general workflow structure is implemented once in the abstract class's algorithm, and necessary variations are implemented in the subclasses.
Class Diagram for Template pattern:
____________________________
|     AbstractClass         |
____________________________
|     +TemplateMethod()     |   - - - - - - - - - - - - - - - - - PrimitiveOperation1()
|     +PrimitiveOperation1()|                                     PrimitiveOperation2()
|     +PrimitiveOperation2()|
____________________________
             ^
             |
             |
_____________________________
|     ConcreteClass          |
_____________________________
|     +PrimitiveOperation1() |
|     +PrimitiveOperation2() |
____________________________


Justification for using Singleton Pattern:
I wanted to ensure that a class only has one instance. Since it can easily access the sole instance of a class, it can control its instantiation.

Class Diagram for Singleton pattern:
____________________________
|      Singleton            |
____________________________
|     -instance: Singleton  |
|     +Instance(): Singleton|
____________________________

