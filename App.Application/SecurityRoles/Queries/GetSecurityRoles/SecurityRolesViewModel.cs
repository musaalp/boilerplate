using System.Collections.Generic;

namespace App.Application.SecurityRoles.Queries.GetSecurityRoles
{
    public class SecurityRolesViewModel
    {
        public SecurityRolesViewModel()
        {
            SecurityRoles = new List<SecurityRoleDto>();
        }

        public IEnumerable<SecurityRoleDto> SecurityRoles { get; set; }
    }
}
