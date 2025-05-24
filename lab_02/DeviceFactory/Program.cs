using System;
using DeviceFactory.Factories;
using DeviceFactory.Models;

class Program
{
    static void Main(string[] args)
    {
        IProneFactory iproneFactory = new IProneFactoryImpl();
        ILaptop iproneLaptop = iproneFactory.CreateLaptop();
        ISmartphone iproneSmartphone = iproneFactory.CreateSmartphone();

        Console.WriteLine("1.");
        Console.WriteLine("Laptop: " + iproneLaptop.GetModel());
        Console.WriteLine("Smartphone: " + iproneSmartphone.GetModel());

        KiaomiFactory kiaomiFactory = new KiaomiFactoryImpl();
        ILaptop kiaomiLaptop = kiaomiFactory.CreateLaptop();
        ISmartphone kiaomiSmartphone = kiaomiFactory.CreateSmartphone();

        Console.WriteLine("\n2.");
        Console.WriteLine("Laptop: " + kiaomiLaptop.GetModel());
        Console.WriteLine("Smartphone: " + kiaomiSmartphone.GetModel());

        BalaxyFactory balaxyFactory = new BalaxyFactoryImpl();
        ILaptop balaxyLaptop = balaxyFactory.CreateLaptop();
        ISmartphone balaxySmartphone = balaxyFactory.CreateSmartphone();

        Console.WriteLine("\n3.");
        Console.WriteLine("Laptop: " + balaxyLaptop.GetModel());
        Console.WriteLine("Smartphone: " + balaxySmartphone.GetModel());
        Console.ReadLine();

    }
}
