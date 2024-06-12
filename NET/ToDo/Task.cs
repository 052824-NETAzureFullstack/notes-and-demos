namespace ToDo
{
    public class Task
    {    
        // Fields - the "variables" or attributes of a class object
            // Getter - a method that is public that can retrieve a private value
            // Setter - a method that is public that can set a private value
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dueDate { get; set; }
        public bool completed { get; set; }
        // private bool _completed;
        // public bool get_completed()
        //{ 
        //  return this._completed;
        //}

        // Constructor - "builds" the instance of the object class
        // {AccessModifier} {Modifier} [Name] (parameters)
        public Task(string title, string description, DateTime dueDate)
        {
            this.title = title;
            this.description = description;
            this.dueDate = dueDate;
            this.completed = false;
        }

        // Methods - the "function" or behavior of an object
        /*
            Example methods of the auto-property getters and setters.
                public string get_title()
                {
                    return this.title;
                }
                public void set_title(string title)
                {
                    this.title = title;
                    // if (title != null)
                    // {
                    //     this.title = title;
                    // }
                }
        */
    }
}