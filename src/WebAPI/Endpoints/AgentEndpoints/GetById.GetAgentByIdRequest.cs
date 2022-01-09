namespace WebAPI.Endpoints.AgentEndpoints
{
    public class GetAgentByIdRequest
    {
        public const string Route = "Agent/{AgentId}";

        public int AgentId { get; set; }
    }
}