using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using SprintTek.Authorization.Users;
using SprintTek.MultiTenancy;

namespace SprintTek.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}