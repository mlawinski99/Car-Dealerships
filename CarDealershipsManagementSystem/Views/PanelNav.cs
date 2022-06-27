using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealershipsManagementSystem.Views
{
    public static class PanelNav
    {
        public static string? IsActive(ViewContext viewContext, string linkId)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return 
                (activePage != null && activePage.Contains(linkId)) 
                ? "active" 
                : null;
        }
    }
}
