using FluentResults;

namespace CallForPapers.Domain.Models;

public class Statement
{
    public Guid Id { get; }

    public Guid Author { get; }

    public StatementActivity Activity { get; private set; }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public string Outline { get; private set;  }

    public DateTime CreateDate { get; }

    public DateTime? SubmittedTime { get; private set; }

    public Status Status { get; private set;  }
    
    public Statement(
        Guid id,
        Guid author,
        StatementActivity activity,
        string name,
        string description,
        string outline,
        DateTime createDate,
        DateTime? submittedTime,
        Status status
        )
    {
        Id = id;
        Author = author;
        Activity = activity;
        Name = name;
        Description = description;
        Outline = outline;
        CreateDate = createDate;
        SubmittedTime = submittedTime;
        Status = status;
    }
    
    private Statement(){}
    
    public Result Confirm()
    {
        if (Status == Status.Confirmed) 
            return Result.Fail("Unable to confirm the statement twice");
        Status = Status.Confirmed;
        SubmittedTime = DateTime.Now.ToUniversalTime();
        return Result.Ok();
    }

    public void SetActivity(StatementActivity activity)
    {
        Activity = activity;
    }
    
    public void SetInfo(string name, string description, string outline)
    { 
        Name = name;
        Description = description;
        Outline = outline;
    }
}