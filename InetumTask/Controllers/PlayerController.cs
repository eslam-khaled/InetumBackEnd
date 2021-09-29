using InetumTask.Business.BusinessInterface;
using InetumTask.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InetumTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerBusiness _playerBusiness;
        public PlayerController(IPlayerBusiness playerBusiness)
        {
            _playerBusiness = playerBusiness;
        }


        [HttpGet]
        public IEnumerable<PlayerDto> GetPlayersListByTeamId(int TeamId)
        {
            return _playerBusiness.GetPlayersListByTeamId(TeamId);
        }


        [HttpDelete]
        public bool DeletePlayersById(int Id)
        {
            return _playerBusiness.DeletePlayerById(Id);
        }

    }
}
