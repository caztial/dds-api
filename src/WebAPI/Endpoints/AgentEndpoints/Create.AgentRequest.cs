namespace WebAPI.Endpoints.AgentEndpoints
{
    public class CreateAgentRequest
    {
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Coordinator { get; set; }
        public int? GroupId { get; set; }

    }
}