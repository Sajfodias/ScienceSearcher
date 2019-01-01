using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Science_searcher.Models;

namespace Science_searcher.Pages
{
    public class UsersModel : PageModel
    {
        private readonly credential_dbContext _credentias;
        private readonly usersContext _users;

        public UsersModel(credential_dbContext credentials, usersContext users)
        {
            _credentias = credentials;
            _users = users;
        }
        
        [BindProperty]
        public TUsers User { get; set; }

        [BindProperty]
        public TUserPwdGen Credential { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _users.Add(User);
            await _users.SaveChangesAsync();

            
            //_credentias.Add(Credential);
            //await _credentias.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}