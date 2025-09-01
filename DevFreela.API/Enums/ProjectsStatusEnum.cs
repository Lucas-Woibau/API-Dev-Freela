using Microsoft.AspNetCore.Http.HttpResults;

namespace DevFreela.API.Enums
{
    public enum ProjectsStatusEnum
    {
        Created = 0,
        InProgress = 1,
        Suspended = 2,
        Canceled = 3,
        Completed = 4,
        PaymentPending = 5
    }
}
