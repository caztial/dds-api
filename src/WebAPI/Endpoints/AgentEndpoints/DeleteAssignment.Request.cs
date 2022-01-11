namespace WebAPI.Endpoints.AgentEndpoints
{
    public class DeleteAssignmentRequest
    {
        public const string ROUTE = "/Agent/{AgentId}/Assignment/{AssignmentId}";
        public int AgentId { get; set; }
        public int AssignmentId { get; set; }
    }
}