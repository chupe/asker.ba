using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Web.Areas.Domain.Pages.TeamOverview;

public static class ManageNavPages
{
    public static string TeamOverview => "TeamOverview";

    public static string Fees => "Fees";

    public static string Trainings => "Trainings";

    public static string TestingEvents => "TestingEvents";

    public static string Items => "Items";

    public static string Notes => "Notes";

    public static string PersonalDetailsNavClass(ViewContext viewContext)
    {
        return PageNavClass(viewContext, TeamOverview);
    }

    public static string FeesNavClass(ViewContext viewContext)
    {
        return PageNavClass(viewContext, Fees);
    }

    public static string TrainingsNavClass(ViewContext viewContext)
    {
        return PageNavClass(viewContext, Trainings);
    }

    public static string TestingEventsNavClass(ViewContext viewContext)
    {
        return PageNavClass(viewContext, TestingEvents);
    }

    public static string ItemsNavClass(ViewContext viewContext)
    {
        return PageNavClass(viewContext, Items);
    }

    public static string NotesNavClass(ViewContext viewContext)
    {
        return PageNavClass(viewContext, Notes);
    }

    private static string PageNavClass(ViewContext viewContext, string page)
    {
        var activePage = viewContext.ViewData["ActivePage"] as string
                         ?? Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
        return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
    }
}