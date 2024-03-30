using CallForPapers.Domain.Models;

namespace CallForPapers.Application.Queries.StatementActivities.Get;

public class GetStatementActivitiesResult
{
    public string Activity { get; set; }
    
    public string Description { get; set; }

    public GetStatementActivitiesResult (StatementActivity activity)
    {
        Activity = activity.Name;
        Description = activity.Description;
    }
}