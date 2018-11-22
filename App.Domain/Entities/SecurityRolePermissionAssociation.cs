namespace App.Domain.Entities
{
    public class SecurityRolePermissionAssociation : Entity
    {
        public SecurityRole SecurityRole { get; set; }
        public Permission Permission { get; set; }
    }
}
