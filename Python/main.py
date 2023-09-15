import os
import time


def run():
    run = TaskManager()
    run.clear_system()
    run.main_menu()

    # Exit program
    confirm_exit = input("\nPress ENTER or any key to exit...")
    print("Goodbye! Thanks for using my to-do app!")
    run.clear_system()

class TaskManager:
    "Functions that run the task options"

    def __init__(self):
        self.tasks = []
        self.task_amount = 0

    def main_menu(self):
        print("What would you like to do?")
        print("'a' to Add Tasks, 'r' to Remove Tasks, 's' to Show Tasks, or 'q' to Quit")

        prompt = input()
        valid_menu_option = self.is_valid_menu_option(prompt)

        while not valid_menu_option or not prompt:
            print("Invalid Response.\n")
            print("What would you like to do?")
            print("'a' to Add Tasks, 'r' to Remove Tasks, 's' to Show Tasks, or 'q' to Quit")
            prompt = input()
            valid_menu_option = self.is_valid_menu_option(prompt)       

    def is_valid_menu_option(self, input):
        """
            Checks if user has entered the correct term. 
            Returns true or false.
        """
        input_value = input.lower()
        if input_value == "a" or input_value == "r" or input_value == "s" or input_value == "q":
            return True
        else:
            return False


    def add_new_task(self):
        """
            The code below executes functions for if the 'a' button is pressed.

            Tasks will be added in UPPERCASE format to the list of tasks,
            then the amount of tasks increase.

            User will be allowed to enter as many tasks as possible
            until the 'b' key is pressed.
        """
        print("Enter as many tasks as needed.")
        print("When done, enter 'b' to go back\n")

        # Add tasks until user is done (enters 'b')
        while True:
            add_task = input("I need to... ")
            if add_task == "":
                print("Enter a task!")
            elif add_task.lower() == "b":
                print("Heading back...")
                self.clear_system()
                break
            else:
                task = add_task.upper()
                print(f"{task} : Task Added\n")
                
                # Add task to tasks list and increment task amount
                self.tasks.append(task)
                self.task_amount += 1
    
    def task_view(self):
        """Displays tasks with option to return to menu"""

        self.format_tasks()
        back_option = input("Type 'b' to go back ")

        if back_option.lower() == 'b':
            print("Heading back...")
            self.clear_system()

    def clear_system(self):
        """Handles function to clean console."""           
        time.sleep(2)
        os.system('clear')

    def format_tasks(self):
        """Makes the list of tasks pretty to look at."""

        print(f"\t\t\t-----You have {self.task_amount} task(s)-----\n")

        if self.task_amount > 0: # If user has any tasks to display
            print("Task No.\t\tTask Name")
            for idx, task in enumerate(self.tasks, start=1):
                print(f"{idx}\t\t\t~ {task.title()}")      
        
run()