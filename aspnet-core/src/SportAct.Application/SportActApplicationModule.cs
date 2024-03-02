using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SportAct.Domain;
using SportAct.MyIdentity;
using System;
using System.Collections.Generic;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Microsoft.AspNetCore.Authorization;




namespace SportAct;

[DependsOn(
    typeof(SportActDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(SportActApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class SportActApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SportActApplicationModule>();
        });
        // Configure your custom app service
       // context.Services.AddScoped<MyIdentityAppService>();
        context.Services.AddTransient<IdentityUserAppService, MyIdentityAppService>();
       

        Configure<AuthorizationOptions>(options =>
        {
            options.AddPolicy("MyIdentityPolicy", policy =>
            {
               policy.RequireAuthenticatedUser(); // Require the user to be authenticated
                                                   // Add additional requirements if needed
            });
        });

    }
}

