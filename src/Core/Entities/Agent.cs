using SharedKernal;
using SharedKernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Agent : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Coordinator { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        private readonly List<AgentAssignment> _assignments = new();
        public IEnumerable<AgentAssignment> Assignments => _assignments.AsReadOnly();
        public DateTimeOffset CreatedOn { get; private set; }
        public Agent(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
            CreatedOn = DateTimeOffset.UtcNow;
        }

        private Agent() { }

        public IEnumerable<AgentAssignment> AllocateAssignment(int accountId)
        {
            AgentAssignment newAssignemnt = new(Id, accountId);
            _assignments.Add(newAssignemnt);
            return Assignments;
        }

        public bool RemoveAssignment(int assignmentId)
        {
            AgentAssignment? removeAssignment = _assignments.Find(a => a.Id.Equals(assignmentId));
            if(removeAssignment != null)
            {
                return _assignments.Remove(removeAssignment);
            }
            return false;
        }

        public bool UpdateAssignemntStatus(int assignmentId, bool status)
        {
            AgentAssignment? updateAssignment = _assignments.Find(a => a.Id.Equals(assignmentId));
            if(updateAssignment != null)
            {
                updateAssignment.UpdateAssignmentStatus(status);
                return true;
            }
            return false;
        }

        public bool CheckUsernameAndPassword(string username, string password)
        {
            return (Username == username && Password == password);
        }
    }
}
