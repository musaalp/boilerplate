using System.Collections.Generic;

namespace App.Application.Permissions.Queries.GetPermissions
{
    public class PermissionsViewModel
    {
        public PermissionsViewModel()
        {
            Permissions = new List<PermissionDto>();
        }

        public IEnumerable<PermissionDto> Permissions { get; set; }
    }
}
