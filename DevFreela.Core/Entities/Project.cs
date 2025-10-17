using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public const string INVALID_STATE_MESSAGE = "Project is in invalid state.";
        protected Project() { }
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
            : base()
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            Status = ProjectsStatusEnum.Created;
            Comments = [];
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjectsStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status == ProjectsStatusEnum.InProgress || Status == ProjectsStatusEnum.Suspended)
            {
                Status = ProjectsStatusEnum.Canceled;
            }
        }

        public void Start()
        {
            if (Status != ProjectsStatusEnum.Created)
            {
                throw new InvalidOperationException(INVALID_STATE_MESSAGE);
            }

            Status = ProjectsStatusEnum.InProgress;
            StartedAt = DateTime.Now;
        }

        public void Complete()
        {
            if (Status == ProjectsStatusEnum.PaymentPending || Status == ProjectsStatusEnum.InProgress)
            {
                Status = ProjectsStatusEnum.Completed;
                CompletedAt = DateTime.Now;
            }
        }

        public void SetPaymentPending()
        {
            if (Status == ProjectsStatusEnum.InProgress)
            {
                Status = ProjectsStatusEnum.PaymentPending;
            }
        }

        public void Update(string title, string desciption, decimal totalCost)
        {
            Title = title;
            Description = desciption;
            TotalCost = totalCost;
        }
    }
}
