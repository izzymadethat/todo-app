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
            ClearSystem(); // initialize console

            Console.WriteLine("\t\t\t=== To-Do List ===\n");

            while (true)
            {
                // main menu options
                string MainMenuOption = MainMenu();
                if (MainMenuOption == "q") // Exit code entirely
                {
                    string exit_ = ConfirmExit();
                    if (exit_ == "q")
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
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
            Console.WriteLine("Goodbye! Thanks for using my to-do app!");
            ClearSystem();
        }

        static string ConfirmExit()
        {
            // Final confirmation before exiting program
            bool quitApp = false;
            Console.WriteLine("\nPress 'q' again to quit or 'b' to go back...");
            string exit_confirm = Console.ReadLine();

            while (!quitApp)
            {
                if (exit_confirm.ToLower() == "q")
                {
                    quitApp = true;
                }
                else if (exit_confirm.ToLower() == "b")
                {
                    Console.WriteLine("Heading back...");
                    ClearSystem();
                    quitApp = true;
                }
                else
                {
                    Console.WriteLine("'b' to go back or 'q' to quit.");
                    exit_confirm = Console.ReadLine();
                }
            }

            return exit_confirm.ToLower();

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
                    Console.WriteLine("Heading back...");
                    ClearSystem();
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
            DisplayTasks(taskList.ToArray());
            GoBack();
        }

        static void DisplayTasks(string[] list)
        {
            // Refactored code to clean FormatTasks function

            if (list.Length > 0) // Display amount of tasks if there's any.
            {
                Console.WriteLine("\nTask No.\t\t\tTask\n");
                for (int i = 0; i < list.Length; i++)
                {
                    Console.WriteLine($"{i + 1}\t\t\t\t{list[i]}");
                }

                Thread.Sleep(2000);
            }
        }
        static void FormatTasks(string[] list)
        {
            // Code written to show user the tasks they have written.

            if (list == taskList.ToArray())
            {
                Console.WriteLine($"\t\t\t----You have {list.Length} task(s)");
                DisplayTasks(taskList.ToArray());
            }
            else if (list == removedTasks.ToArray())
            {
                Console.WriteLine($"\t\t\t----You have {list.Length} removed task(s).----\n");
                DisplayTasks(removedTasks.ToArray());
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


            while (true)
            {
                Console.WriteLine("\nWhat would you like to remove?");
                Console.WriteLine("Type 'b' to go back or 'a' to remove all tasks.");
                Console.WriteLine("Otherwise, type the number of the task you wish to move.");
                Console.WriteLine("You can also type 't' to view your removed tasks");

                FormatTasks(taskList.ToArray());
                DisplayTasks(taskList.ToArray());
                string index = Console.ReadLine();

                switch (index.ToLower())
                {
                    case "b":
                        Console.WriteLine("Heading Back...");
                        ClearSystem();
                        return; // Exits the function entirely
                    case "":
                        ClearSystem();
                        return;
                    case "a":
                        RemoveAllTasks();
                        ClearSystem();
                        return;
                    case "t":
                        FormatTasks(removedTasks.ToArray());
                        break;
                    default:
                        try
                        {
                            int indexNumber = Convert.ToInt32(index);

                            if (indexNumber > 0 && indexNumber <= taskList.Count)
                            {
                                int i = indexNumber-1; // list starts at 0 instead of 1
                                Console.WriteLine($"'{taskList[i]}' removed.");
                                removedTasks.Add(taskList[i]); // Add to removed tasks list
                                taskList.RemoveAt(i); // Remove task at specified index
                                taskAmount--;

                                Console.WriteLine("Press 'Enter'");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Not a valid position in list.");
                                break;
                            }

                        }
                        catch (ArgumentOutOfRangeException) // If user has no tasks at all
                        {
                            Console.WriteLine("Not a valid position in list.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter a valid menu item or number.");
                        }
                        break;
                }
            }
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
