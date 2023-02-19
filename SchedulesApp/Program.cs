using SchedulesApp.Classes;
using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        //The input.txt file should be in the following location: "C:\...\source\repos\SchedulesApp\bin\Debug\net6.0" 
        string EmployeesList = "input.txt";

        //Calls the INputHandler Class
        OutputHandler app = new OutputHandler();

        //Once the class is initiated, we specify it to load the txt file
        app.Init(EmployeesList);

        Console.ReadLine();
    }
}


