﻿using System.Web;
using System.Web.Mvc;

namespace Insure.Partners.Hub
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
