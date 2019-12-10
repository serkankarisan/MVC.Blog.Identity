using Blog.BLL.Identity;
using Blog.DAL.Context;
using Blog.Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog.PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (BlogContext ent = new BlogContext())
            {
                ent.Database.CreateIfNotExists();
            }
            var usermanager = IdentityTools.NewUserManager();
            var rolemanager = IdentityTools.NewRoleManager();
            if (usermanager.FindByName("serkankarisan1905@gmail.com") == null)
            {
                try
                {
                    ApplicationUser AppUserAdmin = new ApplicationUser() { Name = "Serkan", Surname = "Karışan", Email = "serkankarisan1905@gmail.com", UserName = "serkankarisan1905@gmail.com", EmailConfirmed = true, SecurityStamp = "d6b253a0-6325-410b-bed4-796ba916e443", PhoneNumber = "5355063330", PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0 };
                    IdentityResult result = usermanager.Create(AppUserAdmin, "123Qw.");
                    if (result.Succeeded)
                    {
                        if (rolemanager.FindByName("Admin") != null)
                        {
                            ApplicationRole Rol = rolemanager.FindByName("Admin");
                            var currentUser = usermanager.FindByName(AppUserAdmin.UserName);
                            usermanager.AddToRole(currentUser.Id, "Admin");
                        }
                        else
                        {
                            ApplicationRole appRole = new ApplicationRole();
                            appRole.Name = "Admin";
                            rolemanager.Create(appRole);
                            var currentUser = usermanager.FindByName(AppUserAdmin.UserName);
                            usermanager.AddToRole(currentUser.Id, "Admin");
                        }
                        if (rolemanager.FindByName("User") == null)
                        {
                            ApplicationRole appRole = new ApplicationRole();
                            appRole.Name = "User";
                            rolemanager.Create(appRole);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    throw;
                }
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
