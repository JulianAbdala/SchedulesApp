## Architecture 

The program has three main functions divided into 4 classes and their respective interfaces, making use of OOP principles:

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

-InputParser divides the text line by line using `StreamReader` and several other specific functions for manipulating this type of data such as `DateTime`, `DayOfWeek`, `Split` and `Parse` into a dictionary called `employeeSchedules`.

-In the same parsing function, every date is formated into a list of objects using `OverlapHandler`.

-In `OverlapHandler`, the day, entry time, and exit time are separated, and then `CheckOverlap` is used to validate if there is an overlap. If the result is greater than 0, there is an overlap.

-Once the dictionary with the employees' schedules is created, `OutputHandler` initiates the process of counting and listing overlaps with every employee. For this, a specific class called `OverlapCounter.cs` was created.

-`OverlapCounter.cs` has a main method called `CreateOutputText` which takes employeeSchedules and compares between every employee, first compares they are not the same and then calls a second function called `CountOverlaps` that takes the list of schedules of both employees and uses the already explained method `CheckOverlap` to validate and then count if there is an overlap.

The names of each employees are sent to `OutputHandler` along with the total number of overlap matches, and then it is printed.

--------------------------------------------------------------------------------------------------------------------------------

**How to use:**

-Clone the repository and execute SchedulesAPP.sln with Visual Studio, once there run the console. -There is sample input.txt in SchedulesApp/bin/Debug/net6.0/

--------------------------------------------------------------------------------------------------------------------------------

*Julian Abdala*
