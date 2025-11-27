using System;

namespace FirstSteps.entity
{
    public abstract class Entity
    {
        public abstract void DisplayObject();

        protected void Display(string textToDisplay, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor originalForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(textToDisplay);
            Console.ForegroundColor = originalForegroundColor;
        }
    }
}
