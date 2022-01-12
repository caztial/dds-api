namespace WebAPI.Endpoints.AgentEndpoints
{
    public class DeleteAllPendingAssignmentRequest
    {
        public const string ROUTE = "/Agent/{AgentId}/Assignment";
        public int AgentId { get; set; }
    }
}