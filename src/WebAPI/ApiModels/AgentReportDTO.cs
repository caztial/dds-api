namespace WebAPI.ApiModels
{
    public class AgentReportDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Coordinator { get; set; }
        public string? Group { get; set; }
        public int Assigned {get; set; }
        public int Complete { get; set; }
    }
}
