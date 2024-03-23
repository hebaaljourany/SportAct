using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SportAct.Domain;
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
using SportAct.Controllers;
using Volo.Abp.AspNetCore.Mvc;
using SportAct.MyAccount;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(MyAccountController).Assembly);
        });
        context.Services.AddTransient<AccountAppService, MyAccountAppService>();
        // context.Services.AddTransient<IMyAccountAppService, MyAccountAppService>();
        /* context.Services.Replace(
     ServiceDescriptor.Transient<IAccountAppService, IMyAccountAppService>()*/
        context.Services.Replace(
     ServiceDescriptor.Transient<IAccountAppService, MyAccountAppService>());

        // context.Services.AddTransient<IAccountService, AccountService>();
        // Add your custom controller to dependency injection
        //context.Services.AddTransient<MyAccountController>();
        //context.Services.AddTransient<MyAccountController>();
        /*Configure<AbpAspNetCoreMvcOptions>(options =>
         {
             options.IgnoredControllersOnModelExclusion
                    .AddIfNotContains(typeof(MyAccountController));
         });*/
    }
}

