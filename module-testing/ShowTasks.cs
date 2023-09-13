// Refactored code to handle if user enters 's' in the MainMenu (rough draft)

// static void ShowTasks(int taskAmount, List<string> taskList)
// {
//     // Code written to show user the tasks they have written.

//     Console.WriteLine($"You have {taskAmount} tasks.");

//     if (taskAmount > 0)
//     {
//         Console.WriteLine("\nTask No.\t\t\tTask\n");
//         for (int i = 0; i < taskList.Count; i++)
//         {
//             Console.WriteLine($"{i + 1}\t\t\t\t{taskList[i]}");
//         }
//     }
// }

// static bool ReturnToMainMenu(string backOption)
// {
//     Console.WriteLine("\nPress 'b' to go back.");
//     backOption = Console.ReadLine();

//     if (backOption == "b")
//     {
//         Console.WriteLine("Going back. Press Enter to Continue.\n");
//         Console.ReadKey();
//         Console.Clear();

//         return true;
//     }

//     return false;
// }
