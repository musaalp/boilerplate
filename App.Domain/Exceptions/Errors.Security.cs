namespace App.Domain.Exceptions
{
    public static partial class Errors
    {
        public static readonly Error Security_EmailAddressInValid = new Error("Email address is not valid");
        public static readonly Error Security_UserLocked = new Error("User is locked");
        public static readonly Error Security_AddSecurityRoleAuthError = new Error("You are not authorized to add a new security role");
        public static readonly Error Security_AssignPermissionAuthError = new Error("You are not authorized to assign permission");
    }
}
