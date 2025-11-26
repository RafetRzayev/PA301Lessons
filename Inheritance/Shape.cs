using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class Shape
    {
        public abstract void Draw();
    }

    class Triangle : Shape
    {
        public int Height {  get; set; }

        public override void Draw()
        {
            Console.WriteLine("triangle draw");
        }
    }

    class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override void Draw()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if ((i == 0 || i == Width - 1) || (j == 0 || j == Height - 1))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();    
            Console.WriteLine();    

        }
    }

}
