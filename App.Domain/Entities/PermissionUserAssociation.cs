namespace App.Domain.Entities
{
    public class PermissionUserAssociation : Entity
    {
        public virtual Permission SecurityRole { get; set; }
        public virtual User User { get; set; }
    }
}
