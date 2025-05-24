using System;

class Program
{
    static void Main()
    {
        Virus parentVirus = new Virus("AntonioVirus", "TokhaX", 7, 32.7);

        Virus childVirus1 = new Virus("InfernoVirus", "Inferno", 3, 21.3);
        parentVirus.AddChild(childVirus1);

        Virus childVirus2 = new Virus("PhantomVirus", "Phantom", 2, 12.8);
        childVirus1.AddChild(childVirus2);

        Console.WriteLine("Details of the original virus hierarchy:");
        parentVirus.DisplayInfo();

        Virus clonedVirus = (Virus)parentVirus.Clone();

        Console.WriteLine("\nDetails of the cloned virus hierarchy:");
        clonedVirus.DisplayInfo();

        Console.WriteLine("\nVerifying if child viruses were cloned correctly:");
        Console.WriteLine($"Name of original's first child: {parentVirus.Children[0].Name}, name of clone's first child: {clonedVirus.Children[0].Name}");

        Console.WriteLine($"Name of original's grandchild: {parentVirus.Children[0].Children[0].Name}, name of clone's grandchild: {clonedVirus.Children[0].Children[0].Name}");

        Console.ReadLine();




    }
}
