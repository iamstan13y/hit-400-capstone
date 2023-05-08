﻿using Microsoft.AspNetCore.Mvc;

namespace iDent.Web.Controllers
{
    public class InvitationsController : Controller
    {
        private readonly IInvitationService _invitationService;

        public InvitationsController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        public async Task<IActionResult> Index()
        {
            var invitations = await _invitationService.GetAllAsync();
            return View();
        }
    }
}