using Microsoft.AspNetCore.Mvc.Rendering;


        public static class MvcExtensions
        {
            public static string ActiveLinkClass(this IHtmlHelper htmlHelper, string? controllers = null, string? actions = null, string cssClass = "active")
            {
                var currentController = htmlHelper?.ViewContext.RouteData.Values["controller"] as string;
                var currentAction = htmlHelper?.ViewContext.RouteData.Values["action"] as string;

                var acceptedControllers = (controllers ?? currentController ?? "").Split(',');
                var acceptedActions = (actions ?? currentAction ?? "").Split(',');

                return acceptedControllers.Contains(currentController) && acceptedActions.Contains(currentAction)
                    ? cssClass
                    : "";
            }
            public static string GetReviewTerm(int? id)
            {

                    if (id == 1)
                    {
                        return "قبول";
                    }else if(id == 2)
                    {
                        return "تحفظ";
                    } else if(id == 3)
                    {
                        return "رد";
                    }
                    else
                    {
                        return "لا";
                    }
                       

                
            }
}
    

