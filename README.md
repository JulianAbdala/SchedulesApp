# SchedulesApp
Takes a .txt input and analizes if an schedule between two employees has overlaped and how many times it did it.

--------------------------------------------------------------------------------------------------------------------------------

## Approach

The biggest challenge was analyzing the schedules where the employees did not exactly match in date and time of entry and exit.

**My solution idea was the manipulation of dictionaries.**

At first, I started by creating a monolithic program where all the classes, functions, and methods were in the same Program.cs. My priority was to make it work as soon as possible, so I could later improve and make it more complex.

By reading a lot of documentation on file loading and manipulating dates and times, I was able to create the logic for `inputParser` . One of my main problems was separating the day from the entry time, so I had to add an underscore "_".

Then, I began to think about the logic for "checkOverlap" and the comparison of the current instance of the object with the previous one.

I decided to divide the overlap function into two separate classes, one that iterates over the names and schedules of each employee, and another that maintains the logic to validate the number of overlaps.

Finally, I decided to create another class that handles the startup functions and leave Program.cs as clear as possible.

--------------------------------------------------------------------------------------------------------------------------------

## Architecture 

The program has three main functions divided into 4 classes making use of OOP:

Input/output manipulation:

- OutputHandler.cs

File transformation and data division:

- InputParser.cs

Overlap logic:

- OverlapCounter.cs

- OverlapHandler.cs

--------------------------------------------------------------------------------------------------------------------------------

## How it works:

-In `Program.cs`, the path to the `.txt` file is specified, and `OutputHandler.cs` is called to initiate the program's operation.

-`OutputHandler.cs` initializes a dictionary using the overlap logic in `OverlapHandler.cs` and takes values from InputParser.cs.

-InputParser divides the text line by line using "StreamReader" and several other specific functions for manipulating this type of data such as DateTime, DayOfWeek, Split and Parse into a dictionary called 'employeeSchedules'

-In the same parsing function, every date is formated into a list of objects using OverlapHandler

-In `OverlapHandler`, the day, entry time, and exit time are separated, and then `CheckOverlap` is used to validate if there is an overlap. If the result is greater than 0, there is an overlap.

-Once the dictionary with the employees' schedules is created, `OutputHandler` initiates the process of counting and listing overlaps with every employee. For this, a specific class called `OverlapCounter.cs` was created.

-`OverlapCounter.cs` has a main method called `CreateOutputText` which takes employeeSchedules and compares between every employee, first compares they are not the same and then calls a second function called 'CountOverlaps' that takes the list of schedules of both employees and uses the already explained method `CheckOverlap` to validate and then count if there is an overlap.

The names of each employees are sent to `OutputHandler` along with the total number of overlap matches, and then it is printed.

--------------------------------------------------------------------------------------------------------------------------------

**How to use:**

-Clone the repository and execute SchedulesAPP.sln with Visual Studio, once there run the console. -There is sample input.txt in SchedulesApp/bin/Debug/net6.0/

--------------------------------------------------------------------------------------------------------------------------------

*Julian Abdala*
