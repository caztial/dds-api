using SharedKernal;
using SharedKernal.Interfaces;

namespace Core.Entities
{
    public class Group: IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Group(string name)
        {
            Name = name;
        }
    }
}
