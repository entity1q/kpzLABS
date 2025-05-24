﻿using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread t1 = new Thread(() => TestAuthenticator("ChatGPT1"));
        Thread t2 = new Thread(() => TestAuthenticator("ChatGPT2"));
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Authenticator auth1 = Authenticator.GetInstance();
        auth1.Authenticate("UserGPT", "password123");
        Console.ReadLine();

    }

    static void TestAuthenticator(string username)
    {
        Authenticator auth = Authenticator.GetInstance();
        auth.Authenticate(username, "password");
    }

}
