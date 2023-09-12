// To Do List Console App - Isaiah Vickers

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace MyFirstProgram
{
    class Program
    {

        static void Main(string[] args)
        {
            // To - Do List

            Console.WriteLine("\t\t\t=== To-Do List ===\n");

            int taskAmount = 0; // init # of tasks
            List<string> taskList = new List<string>();

            while (true) 
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("'a' to Add, 'r' to remove, 's' to show tasks, or 'q' to quit ");
                string prompt = Console.ReadLine();
                
                if (prompt.ToLower() == "q") // If 'q' is pressed, the program stops completely.
                {
                    break;
                }
                
                /* 
                    The code below executes functions for if the 'a' button is pressed.
                    Tasks will be added in UPPERCASE format to the list of tasks, then the amount of tasks increase.
                    User will be allowed to enter as many tasks as possible until the 'b' key is pressed.
                */
                else if (prompt == "a") 
                {
                    Console.WriteLine("Enter as many tasks as needed. When done, enter 'b' to go back");
                    
                    while (true)
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

                        taskList.Add(task);
                        taskAmount++;
                    }
                    
                    
                }
                else if (prompt == "s")
                {
                    Console.WriteLine($"You have {taskAmount} tasks.");
                                      
                    if (taskAmount > 0) 
                    {
                        Console.WriteLine("\nTask No.\t\t\tTask\n");
                        for (int i = 0; i < taskList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}\t\t\t\t{taskList[i]}");
                        }
                    }

                    Console.WriteLine("\nPress 'b' to go back.");
                    string back = Console.ReadLine();
                    if (back == "b")
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else if (prompt == "r")
                {
                    if (taskAmount > 0)
                    {
                        Console.WriteLine("\nTask No.\t\t\tTask\n");
                        for (int i = 0; i < taskList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}\t\t\t\t{taskList[i]}");
                        }
                        Console.WriteLine("What would you like to remove?");
                        Console.WriteLine("Type 0 to go back or -1 to remove all tasks. Otherwise, type the number of the task you wish to move.");
                        
                        int index = Convert.ToInt32(Console.ReadLine());
                        
                        if (index == 0) 
                        {
                            continue; // Go back to menu if user doesn't want to remove tasks.
                        }
                        else if (index == -1) 
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
                                    Console.WriteLine("Press 'Enter' to go back");

                                    Console.ReadKey();
                                    Console.Clear();
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
                        else if (index > 0 && index <= taskList.Count) 
                        {
                            int i = index-1;
                            Console.WriteLine($" '{taskList[i]}' removed.");
                            taskList.RemoveAt(i); // Remove task at specified index (index-1 because list starts at 0 instead of 1)
                            taskAmount--;

                            Console.WriteLine("Press 'Enter'");
                            Console.ReadKey();
                            
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Not a valid position in list.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have no tasks to remove.");
                        continue;
                    }
                    
                }
                
            }

            

            Console.ReadKey();
        }
    }
}