using System;
namespace ToDo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // keep a running list of tasks to be completed, and be able to remove the task from the list when complete.
            // Collections help us group similar type objects(variables)
            // Arrays - can be multi-dimensional - items are referenced by index position(s) - immutable in size.
            // List - dynamic arrays - items are referenced by index, add, remove, pop (remove items from the middle)


            List<Task> toDoList = new List<Task>();
            bool repeat = true;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] - Add a to-do to the list.");
                Console.WriteLine("[2] - Display incomplete to-do tasks.");
                Console.WriteLine("[3] - Complete a to-do from the list");
                Console.WriteLine("[4] - Display all to-do tasks.");
                Console.WriteLine("[0] - Exit the app");
                int selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1: // add a task to the list
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your todo title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Please enter your todo description: ");
                        string description = Console.ReadLine();
                        DateTime now = DateTime.Now;

                        Task newTask = new Task(title, description, now);

                        toDoList.Add(newTask);
                        break;
                    }
                    
                    case 2: // display the incomplete tasks
                    {         
                        Console.Clear();               
                        foreach(Task item in toDoList)       
                        {
                            if (!item.completed)
                            {
                                Console.WriteLine("{0} - {1}", item.title, item.dueDate);
                                Console.WriteLine("\t" + item.description);
                            }
                        } 
                        Console.ReadLine();
                        break; 
                    }

                    case 3: // complete an item from the list
                    {
                        Console.Clear();
                        Console.WriteLine("Which item do you want to complete?");
                        for ( int i = 0; i < toDoList.Count; i++)
                        {
                            Console.WriteLine("[{0}] - {1}", i, toDoList[i].title);
                        }

                        int index = int.Parse(Console.ReadLine());
                        toDoList[index].completed = true;

                        Console.WriteLine("Task completed! Keep up the good work!");
                        Console.ReadLine();
                        break;
                    }

                    case 4: // display the list
                    {         
                        Console.Clear();               
                        foreach(Task item in toDoList)       
                        {
                            Console.WriteLine("{0} - {1}", item.title, item.dueDate);
                            Console.WriteLine("\t" + item.description);
                        } 
                        Console.ReadLine();
                        break; 
                    }

                    case 0: // Exit
                    {
                        repeat = false;
                        break;
                    }
                }
            }

            Console.WriteLine("Exiting...");                
        } 
    }
}
