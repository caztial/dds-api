namespace WebAPI.Endpoints.AgentEndpoints
{
    public class UpdateAssignmentRequest
    {
        public const string ROUTE = "/Agent/{AgentId}/Assignment/{AssignmentId}";
        public const string COMPLETE_ROUTE = "/Agent/{AgentId}/Assignment/{AssignmentId}/Complete";
        public int AgentId { get; set; }
        public int AssignmentId { get; set; }
    }
}