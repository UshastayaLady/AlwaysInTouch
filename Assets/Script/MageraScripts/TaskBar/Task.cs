using System.Collections.Generic;

public class Task
{
    public string taskName;
    public string status;

    public Task(string name)
    {
        taskName = name;
        status = "Pending";
    }
}
