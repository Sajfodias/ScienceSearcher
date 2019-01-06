using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Science_searcher.Pages
{
    public class UrlSeedAddModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {
                var inputUrl = Request.Form["urlSeed"];
                Logic.Downloader downloader = new Logic.Downloader();
                downloader.AddSeedToDb(inputUrl);
            }
            catch(Exception ex)
            {
                throw new Exception("Exception occured during adding new url seed to database", ex);
            }
        }
    }
}