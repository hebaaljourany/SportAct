using SportAct.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SportAct.Permissions;

public class SportActPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SportActPermissions.GroupName);

        var citiesPermission = myGroup.AddPermission(SportActPermissions.Cities.Default, L("Permission:Cities"));
        citiesPermission.AddChild(SportActPermissions.Cities.Create, L("Permission:Cities.Create"));
        citiesPermission.AddChild(SportActPermissions.Cities.Edit, L("Permission:Cities.Edit"));
        citiesPermission.AddChild(SportActPermissions.Cities.Delete, L("Permission:Cities.Delete"));


        var locationPermission = myGroup.AddPermission(SportActPermissions.Locations.Default, L("Permission:Locations"));
        locationPermission.AddChild(SportActPermissions.Locations.Create, L("Permission:Locations.Create"));
        locationPermission.AddChild(SportActPermissions.Locations.Edit, L("Permission:Locations.Edit"));
        locationPermission.AddChild(SportActPermissions.Locations.Delete, L("Permission:Locations.Delete"));


        var activityTypePermission = myGroup.AddPermission(SportActPermissions.ActivityTypes.Default, L("Permission:ActivityTypes"));
        activityTypePermission.AddChild(SportActPermissions.ActivityTypes.Create, L("Permission:ActivityTypes.Create"));
        activityTypePermission.AddChild(SportActPermissions.ActivityTypes.Edit, L("Permission:ActivityTypes.Edit"));
        activityTypePermission.AddChild(SportActPermissions.ActivityTypes.Delete, L("Permission:ActivityTypes.Delete"));

        var sportctiviyPermission = myGroup.AddPermission(SportActPermissions.SportActivities.Default, L("Permission:SportActivities"));
        sportctiviyPermission.AddChild(SportActPermissions.SportActivities.Create, L("Permission:SportActivities.Create"));
        sportctiviyPermission.AddChild(SportActPermissions.SportActivities.Edit, L("Permission:SportActivities.Edit"));
        sportctiviyPermission.AddChild(SportActPermissions.SportActivities.Delete, L("Permission:SportActivities.Delete"));


        var reservationPermission = myGroup.AddPermission(SportActPermissions.Reservations.Default, L("Permission:Reservations"));
        reservationPermission.AddChild(SportActPermissions.Reservations.Create, L("Permission:Reservations.Create"));
        reservationPermission.AddChild(SportActPermissions.Reservations.Edit, L("Permission:Reservations.Edit"));
        reservationPermission.AddChild(SportActPermissions.Reservations.Delete, L("Permission:Reservations.Delete"));



    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SportActResource>(name);
    }
}
