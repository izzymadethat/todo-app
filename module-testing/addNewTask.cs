// Refactored code to execute when user enters 'a' on main menu (rough draft)
using System;

static void addNewTask(List<string> taskList, int taskAmount)
{
    Console.WriteLine("Enter as many tasks as needed. When done, enter 'b' to go back");

    while (true) // Allows user to continue adding tasks until 'b' is entered
    {
        Console.WriteLine("I need to...");
        string task = Console.ReadLine();

        if (task.ToLower() == "b")
        {
            Console.Clear();
            break;
        }

        task = task.ToUpper();

        Console.WriteLine("Task added.");
        Console.WriteLine();

        taskList.Add(task);
        taskAmount++;
    }
}
