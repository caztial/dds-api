using SharedKernal;

namespace Core.Entities
{
    public class AgentAssignment
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int AccountId { get; set; }
        public int Count { get; set; }
        public bool Status { get; set; }
        public DateTimeOffset AssignemntOn { get; set; }
        public DateTimeOffset LastUpdateOn { get; set; }
        
        public AgentAssignment(int agentId, int accountId)
        {
            AgentId = agentId;
            AccountId = accountId;
            Status = false;
            Count = 0;
            AssignemntOn = DateTimeOffset.UtcNow;
            LastUpdateOn = DateTimeOffset.UtcNow;
        }
        
        public void UpdateAssignmentStatus(bool status, int count=5)
        {
            Status = status;
            if(status)
                Count = count;
            LastUpdateOn = DateTimeOffset.UtcNow;
        }

    }
}
