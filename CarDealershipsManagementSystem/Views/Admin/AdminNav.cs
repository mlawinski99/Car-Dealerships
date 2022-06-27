using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealershipsManagementSystem.Views.Admin
{
    public static class AdminNav
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
