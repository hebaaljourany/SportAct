namespace SportAct.Permissions;

public static class SportActPermissions
{
    public const string GroupName = "SportAct";

    public static class Cities
    {
        public const string Default = GroupName + ".Cities";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Locations
    {
        public const string Default = GroupName + ".Locations";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class ActivityTypes
    {
        public const string Default = GroupName + ".ActivityTypes";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class SportActivities
    {
        public const string Default = GroupName + ".SportActivities";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Reservations
    {
        public const string Default = GroupName + ".Reservations";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }



    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
