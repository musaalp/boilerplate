namespace App.Domain.Entities
{
    public class SecurityRoleUserAssociation : Entity
    {
        public virtual SecurityRole SecurityRole { get; set; }
        public virtual User User { get; set; }
    }
}
