using System;

namespace Stos
{
    class Program
    {
        static void Main(string[] args)
        {
            StosWTablicy<string> s = new StosWTablicy<string>(2);
            s.Push("km");
            s.Push("aa");
            s.Push("xx");
            foreach (var x in s.ToArray())
                Console.WriteLine(x); 

            Console.WriteLine();

            IStos<char> stos = new StosWTablicy<char>();
            stos.Push('a');
            stos.Push('b');
            stos.Push('c');
            foreach(var x in ((StosWTablicy<char>)stos).TopToBottom){
                Console.WriteLine(x);
            }

            Console.WriteLine();

            IStos<char> stack = new StosWTablicy<char>(2);
            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            Console.WriteLine(stos.Count);
            int licznik = 0;
            foreach(var x in stos)
            {
                Console.WriteLine(x);
                licznik++;
            }
            Console.WriteLine();
            Console.WriteLine(licznik);

            IStos<char> stack2 = new StosWLiscie<char>();
            stack2.Push('a');
            stack2.Push('b');
            stack2.Push('c');
            stack2.Push('d');
            Console.WriteLine(stack2.IsEmpty);
            Console.WriteLine();
            foreach(var x in stack2)
            {
                Console.WriteLine(x);
            }
        }
    }
}
