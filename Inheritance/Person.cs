namespace Inheritance
{
   abstract class Animal
   {
        public abstract void Speak();
    }

    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Woof!");
        }
    }

    class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Meow!");
        }
    }

    class Bird : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Chirp!");
        }
    }
}
