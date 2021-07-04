using BookCartApi.Models;
using BookCartApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookCartApi.Controllers
{
    //
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscribeService;
        private readonly UserManager<User> _userManager;
        public SubscriptionController(ISubscriptionService subscribeService, UserManager<User> userManager)
        {
            _subscribeService = subscribeService;
            _userManager = userManager;
        }
        [HttpGet("GetSubscription/{id}")]
        public async Task<IActionResult> GetSubscription(int id)
        {
            var Items = await _subscribeService.GetSubscription(id);
            return Ok(Items);
        }
        [HttpGet("GetSubscriptions")]
        public async Task<IActionResult> GetSubscriptions()
        {
            var Items = await _subscribeService.GetSubscriptions();
            return Ok(Items);
        }
        [HttpGet("Issubscribe")]
        [Authorize]
        public async Task<IActionResult> Issubscribe(int bookId)
        {
            var val = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByNameAsync(val);
            var Items = await _subscribeService.Issubscribe(user.Id,bookId);
            return Ok(Items);
        }
        [HttpPost("SubscribeOrUnsubscribe")]
        [Authorize]
        public async Task<IActionResult> SubscribeOrUnsubscribe(int subscriptionId, int bookId)
        {
            var val = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByNameAsync(val);
            var Items = await _subscribeService.SubscribeOrUnsubscribe(subscriptionId, bookId, user.Id);
            return Ok(Items);
        }


    }
}
