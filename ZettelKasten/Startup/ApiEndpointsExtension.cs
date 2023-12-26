namespace ZettelKasten.Startup;

public static class ApiEndpointsExtension
{
    public static RouteGroupBuilder ApiGroup(this RouteGroupBuilder group)
    {
        group.MapGroup("/users")
            .UsersGroup()
            .WithTags("Users");

        group.MapGroup("/notes")
            .NotesGroup()
            .WithTags("Notes");

        group.MapGroup("/tags")
            .TagsGroup()
            .WithTags("Tags");

        group.MapGroup("/relations")
            .RelationsGroup()
            .WithTags("Relations");

        return group;
    }
}
