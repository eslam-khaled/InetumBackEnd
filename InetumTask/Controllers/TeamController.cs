using InetumTask.Business.BusinessInterface;
using InetumTask.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InetumTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeamController : ControllerBase
    {
        private readonly ITeamBusiness _teamBusiness;
        public TeamController(ITeamBusiness teamBusiness)
        {
            _teamBusiness = teamBusiness;
        }

        [HttpPost]
        public TeamDto AddTeam(TeamDto teamDto)
        {
            return _teamBusiness.AddTeam(teamDto);
        }

        [HttpDelete]
        public bool DeleteTeamById(int Id)
        {
            return _teamBusiness.DeleteTeamById(Id);
        }

        [HttpPut]
        public TeamDto UpdateTeam(TeamDto teamDto)
        {
            return _teamBusiness.UpdateTeam(teamDto);
        }

        [HttpGet]
        public IEnumerable<TeamDto> GetTeamsList()
        {
            return _teamBusiness.GetTeamsList();
        }

        [HttpGet]
        [Route("GetTeamById")]
        public TeamDto GetTeamById(int Id)
        {
            return _teamBusiness.GetTeamById(Id);
        }


    }
}
