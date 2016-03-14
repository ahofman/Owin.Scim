﻿namespace Owin.Scim.Tests.Integration.Groups.Replace
{
    using System.Net;

    using Machine.Specifications;

    using Model.Groups;

    public class with_a_valid_group_no_members : when_replacing_a_group
    {
        Establish context = () =>
        {
            ExistingGroup = CreateGroup(new Group {DisplayName = "existing group"});

            GroupId = ExistingGroup.Id;

            GroupDto = new Group
            {
                Id = GroupId,
                DisplayName = "new group",
                ExternalId = "hello",
            };
        };

        It should_return_ok = () => Response.StatusCode.ShouldEqual(HttpStatusCode.OK);

        It should_contain_id = () => CreatedGroup.Id.ShouldEqual(ExistingGroup.Id);

        It should_contain_meta = () =>
        {
            CreatedGroup.Meta.ShouldNotBeNull();
            CreatedGroup.Meta.Created.ShouldEqual(ExistingGroup.Meta.Created);
            CreatedGroup.Meta.LastModified.ShouldBeGreaterThan(ExistingGroup.Meta.LastModified);

            CreatedGroup.Meta.Location.ShouldNotBeNull();
            CreatedGroup.Meta.Location.ShouldEqual(Response.Headers.Location);
            CreatedGroup.Meta.Location.ShouldEqual(ExistingGroup.Meta.Location);

            CreatedGroup.Meta.Version.ShouldNotBeNull();
            CreatedGroup.Meta.Version.ShouldEqual(Response.Headers.ETag.ToString());
            CreatedGroup.Meta.Version.ShouldNotEqual(ExistingGroup.Meta.Version);
        };

        private static Group ExistingGroup;
    }
}