using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KalamYouthForumWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalamYouthForumWebApp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [StringLength(50, ErrorMessage = "Please add the local body name", MinimumLength = 1)]
            [Display(Name = "Local Body")]
            public string LocalBody { get; set; }

            [StringLength(50, ErrorMessage = "Please add the District name", MinimumLength = 1)]
            [Display(Name = "District")]
            public string District { get; set; }

            [StringLength(50, ErrorMessage = "Please add the State name", MinimumLength = 1)]
            [Display(Name = "State")]
            public string State { get; set; }

            [Display(Name = "SignUp for Blood Donation?")]
            public bool BloodDonation { get; set; }

            [Display(Name = "Blood Group")]
            public BloodGroupList BloodGroup { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var district = user.District;
            var state = user.State;
            var localBody = user.LocalBody;
            var bloodDonation = user.BloodDonation;
            var bloodGroup = user.BloodGroup;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                LocalBody = localBody,
                District = district,
                State = state,
                BloodDonation = bloodDonation,
                BloodGroup = bloodGroup
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if(Input.District != user.District)
            {
                user.District = Input.District;
            }

            if (Input.LocalBody != user.LocalBody)
            {
                user.LocalBody = Input.LocalBody;
            }

            if (Input.State != user.State)
            {
                user.State = Input.State;
            }

            if (Input.BloodDonation != user.BloodDonation)
            {
                user.BloodDonation = Input.BloodDonation;
            }

            if (Input.BloodGroup != user.BloodGroup)
            {
                user.BloodGroup = Input.BloodGroup;
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
