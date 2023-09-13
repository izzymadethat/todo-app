// Refactored Code to remove tasks (rough draft)

// static void RemoveTasks()
// {
//     // Handles all options to remove tasks.
//     if (taskAmount > 0)
//     {
//         FormatTasks(); // Show user the tasks

//         Console.WriteLine("What would you like to remove?");
//         Console.WriteLine("Type 0 to go back or -1 to remove all tasks. Otherwise, type the number of the task you wish to move.");

//         int index = Convert.ToInt32(Console.ReadLine());

//         switch (index)
//         {
//             case 0:
//                 return;
//             case -1:
//                 RemoveAllTasks();
//                 return;
//             default:
//                 break;
//         }

//         if (index > 0 && index <= taskList.Count)
//         {
//             int i = index-1; // list starts at 0 instead of 1
//             Console.WriteLine($"'{taskList[i]}' removed.");
//             taskList.RemoveAt(i); // Remove task at specified index
//             taskAmount--;

//             Console.WriteLine("Press 'Enter'");
//             Console.ReadKey();
//             Console.Clear();
//         }
//         else // If user has no tasks at all
//         {
//             Console.WriteLine("Not a valid position in list.");
//         }

//     }
//     else
//     {
//         Console.WriteLine("You Have No Tasks to Remove!")
//     }

// }
// static void removeALLTasks()
// {
//     bool removeAll = false;
//     Console.WriteLine("This will remove ALL tasks. Are you sure? (y or n)");

//     while (!removeAll)
//     {
//         string confirm = Console.ReadLine();

//         if (confirm.ToLower() == "y")
//         {
//             taskList.Clear(); // Remove all elements from list
//             Console.WriteLine("All tasks removed.");
//             taskAmount = 0;
//             Console.WriteLine("Press 'Enter' to go back");

//             Console.ReadKey();
//             Console.Clear();
//             removeAll = true;
//         }
//         else if (confirm.ToLower() == "n")
//         {
//             Console.WriteLine("No tasks removed");
//             removeAll = true; // Exits loop without clearing
//         }
//         else
//         {
//             Console.WriteLine("Please enter 'y' or 'n' ");
//         }
//     }

// }
