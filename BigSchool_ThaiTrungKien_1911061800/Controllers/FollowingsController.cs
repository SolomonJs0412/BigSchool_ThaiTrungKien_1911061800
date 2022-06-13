using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool_ThaiTrungKien_1911061800.DTOs;
using BigSchool_ThaiTrungKien_1911061800.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool_ThaiTrungKien_1911061800.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDBContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDBContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists");

            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
