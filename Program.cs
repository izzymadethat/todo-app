// To Do List Console App - Isaiah Vickers
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;

namespace MyFirstProgram
{
    class Program
    {
        static int taskAmount = 0; // init # of tasks
        static List<string> taskList = new List<string>(); // init task list
        static List<string> removedTasks = new List<string>(); // removed task list
        static void Main()
        {
            Console.WriteLine("\t\t\t=== To-Do List ===\n");

            while (true)
            {
                // main menu options
                string MainMenuOption = MainMenu();
                if (MainMenuOption == "q")
                {
                    break; // Exit code entirely
                }
                else if (MainMenuOption == "a")
                {
                    AddNewTask();
                }
                else if (MainMenuOption == "s")
                {
                    ShowTasks();

                }
                else if (MainMenuOption == "r")
                {
                    RemoveTasks();
                }

            }
            Console.WriteLine("Press enter to confirm exit...");
            Console.ReadKey();
        }
        static string MainMenu()
        {
            // Serves as main menu
            string prompt;

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("'a' to add tasks, 'r' to remove, 's' to show tasks, or 'q' to quit ");
            prompt = Console.ReadLine();

            while (string.IsNullOrEmpty(prompt) || !IsValidMenuOption(prompt))
            {
                Console.WriteLine("Invalid Response\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("'a' to add tasks, 'r' to remove, 's' to show tasks, or 'q' to quit ");
                prompt = Console.ReadLine();
            }

            return prompt.ToLower(); // Outputs response letter if a, s, r, or q

        }
        static bool IsValidMenuOption(string input)
        {
            // Check to see if user entered valid menu option
            switch (input)
            {
                case "a":
                    return true;
                case "r":
                    return true;
                case "s":
                    return true;
                case "q":
                    return true;
            }
            return false;

        }
        static void AddNewTask()
        {
            /*
            The code below executes functions for if the 'a' button is pressed.

            Tasks will be added in UPPERCASE format to the list of tasks,
            then the amount of tasks increase.

            User will be allowed to enter as many tasks as possible
            until the 'b' key is pressed.
            */
            Console.WriteLine("Enter as many tasks as needed.");
            Console.WriteLine("When done, enter 'b' to go back\n");

            while (true) // add tasks until 'b'
            {
                Console.WriteLine("I need to...");
                string task = Console.ReadLine();
                task = task.ToLower();

                if (string.IsNullOrEmpty(task))
                {
                    Console.WriteLine("Enter a task");
                }
                else if (task == "b")
                {
                    Console.WriteLine("Going back. Press Enter to Continue.\n");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    task = task.ToUpper();

                    Console.WriteLine($"{task}:Task added.");
                    Console.WriteLine();

                    taskList.Add(task);
                    taskAmount++;
                }
            }

        }
        static void ShowTasks()
        {
            // Displays tasks with option to return to menu
            FormatTasks(taskList.ToArray());
            Console.WriteLine("\nPress 'b' to go back.");
            string backOption = Console.ReadLine();

            if (backOption == "b")
            {
                Console.WriteLine("Going back. Press Enter to Continue.\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void FormatTasks(string[] list)
        {
            // Code written to show user the tasks they have written.
            if (list == taskList.ToArray())
            {
                Console.WriteLine($"\t\t\t----You have {list.Length} task(s).----\n");
            }
            else if (list == removedTasks.ToArray())
            {
                Console.WriteLine($"\t\t\t----You have {list.Length} removed task(s).----\n");
            }

            if (list.Length > 0) // Display amount of tasks if there's any.
            {
                Console.WriteLine("\nTask No.\t\t\tTask\n");
                for (int i = 0; i < list.Length; i++)
                {
                    Console.WriteLine($"{i + 1}\t\t\t\t{list[i]}");
                }
            }
        }
        static void RemoveTasks()
        {
            // All functions to remove any one or all tasks.

            if (taskAmount <= 0) // no tasks available
            {
                Console.WriteLine("Nothing to remove!");
                GoBack();
                return;
            }

            Console.WriteLine("What would you like to remove?");
            Console.WriteLine("Type 'b' to go back or -1 to remove all tasks.");
            Console.WriteLine("Otherwise, type the number of the task you wish to move.");
            Console.WriteLine("You can also type 't' to view your removed tasks");

            while (true)
            {
                FormatTasks(taskList.ToArray());
                string index = Console.ReadLine();

                switch (index)
                {
                    case "b":
                        return; // Exits the function entirely
                    case "-1":
                        RemoveAllTasks();
                        return;
                    case "t":
                        FormatTasks(removedTasks.ToArray());
                        return;
                    default:
                        break;
                }
            }
            // if (taskAmount > 0)
            // {
            //     FormatTasks(); // Show user the tasks


            //     int index = Convert.ToInt32(Console.ReadLine());

            //     switch (index)
            //     {
            //         case 0:
            //             return;
            //         case -1:
            //             RemoveAllTasks();
            //             return;
            //         default:
            //             break;
            //     }

            //     if (index > 0 && index <= taskList.Count)
            //     {
            //         int i = index-1; // list starts at 0 instead of 1
            //         Console.WriteLine($"'{taskList[i]}' removed.");
            //         taskList.RemoveAt(i); // Remove task at specified index
            //         taskAmount--;

            //         Console.WriteLine("Press 'Enter'");
            //         Console.ReadKey();
            //         Console.Clear();
            //     }
            //     else // If user has no tasks at all
            //     {
            //         Console.WriteLine("Not a valid position in list.");
            //     }

            // }
            // else
            // {
            //     Console.WriteLine("You Have No Tasks to Remove!");
            // }

        }
        static void RemoveAllTasks()
        {
            bool removeAll = false;
            Console.WriteLine("This will remove ALL tasks. Are you sure? (y or n)");

            while (!removeAll)
            {
                string confirm = Console.ReadLine();

                if (confirm.ToLower() == "y")
                {
                    taskList.Clear(); // Remove all elements from list
                    Console.WriteLine("All tasks removed.");
                    taskAmount = 0;
                    GoBack();
                    removeAll = true;
                }
                else if (confirm.ToLower() == "n")
                {
                    Console.WriteLine("No tasks removed");
                    removeAll = true; // Exits loop without clearing
                }
                else
                {
                    Console.WriteLine("Please enter 'y' or 'n' ");
                }
            }

        }
        static void GoBack()
        {
            // Handles all back options so I don't have to keep typing it

            Console.WriteLine("Enter 'b' to go back...");
            string back_option = Console.ReadLine();
            back_option = back_option.ToLower();

            if (back_option == "b")
            {
                Console.WriteLine("Heading back...");
                ClearSystem();
            }
        }
        static void ClearSystem()
        {
            // Handles function to delay and clean system.
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
