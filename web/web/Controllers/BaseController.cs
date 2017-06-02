using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public List<string> ErrorModels
        {
            get
            {
                return ModelState
                    .Values
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();
            }
        }
    }
}