namespace App.Domain.Entities
{
    public class Permission : Entity
    {
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
    }
}
