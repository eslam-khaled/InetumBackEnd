using AutoMapper;
using InetumTask.Business.BusinessInterface;
using InetumTask.DAL;
using InetumTask.DAL.BaseRepository;
using InetumTask.DAL.Models;
using InetumTask.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InetumTask.Business.BusinessImplementation
{
    public class TeamBusiness : ITeamBusiness
    {
        private readonly IBaseRepository<Team> _baseRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly IPlayerBusiness _playerBusiness;
        public TeamBusiness(IBaseRepository<Team> baseRepository, IMapper mapper
            , DataContext dataContext, IPlayerBusiness playerBusiness)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _dataContext = dataContext;
            _playerBusiness = playerBusiness;
        }

        /// <inheritdoc/>
        public TeamDto AddTeam(TeamDto teamDto)
        {
            using (_dataContext)
            {
                using (var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {

                        if (teamDto == null || string.IsNullOrEmpty(teamDto.Name))
                        {
                            teamDto.Success = false;
                            teamDto.Message = "Team is null or empty";
                            return teamDto;
                        }

                        Team team = new Team()
                        {
                            CoachName = teamDto.CoachName,
                            Country = teamDto.Country,
                            FoundationDate = teamDto.FoundationDate,
                            Name = teamDto.Name,
                            LogoImage = teamDto.LogoImage
                        };

                        var addedTeam = _baseRepository.AddNew(team);

                        if (addedTeam.Id < 0)
                        {
                            teamDto.Success = false;
                            teamDto.Message = "Couldn't Add";
                            return teamDto;
                        }

                        teamDto.Id = addedTeam.Id;
                        teamDto.Success = true;
                        teamDto.Message = "Added successfully";

                        foreach (var player in teamDto.playerListDto)
                        {
                            player.TeamId = addedTeam.Id;
                        }

                        _playerBusiness.AddPlayersList(teamDto.playerListDto);


                        transaction.Commit();

                        return teamDto;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred." + ex);
                        teamDto.Success = false;
                        teamDto.Message = "Couldn't add";
                        return teamDto;
                    }
                }
            }


        }

        /// <inheritdoc/>
        public bool DeleteTeamById(int Id)
        {
            using (_dataContext)
            {
                using (var transaction = _dataContext.Database.BeginTransaction())
                {
                    try
                    {

                        var team = _baseRepository.GetWhere(x => x.Id == Id).FirstOrDefault();
                        team.IsDeleted = true;
                        _baseRepository.Update(team);

                        _playerBusiness.DeletePlayersByTeamId(Id);

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred." + ex);
                    }

                }

            }
            return false;
        }

        /// <inheritdoc/>
        public TeamDto GetTeamById(int Id)
        {
            var team = _baseRepository.GetWhere(x => x.Id == Id && x.IsDeleted == false).FirstOrDefault();
            TeamDto teamDto = new TeamDto()
            {
                Id = team.Id,
                CoachName = team.CoachName,
                Country = team.Country,
                FoundationDate = team.FoundationDate,
                Name = team.Name,
                LogoImage = team.LogoImage
            };
            return teamDto;
        }

        /// <inheritdoc/>
        public ICollection<TeamDto> GetTeamsList()
        {
            var AllTeams = _baseRepository.GetWhere(x => x.IsDeleted == false);

            List<TeamDto> teamDtoList = new List<TeamDto>();

            foreach (var team in AllTeams)
            {
                teamDtoList.Add(new TeamDto
                {
                    CoachName = team.CoachName,
                    Country = team.Country,
                    FoundationDate = team.FoundationDate,
                    Name = team.Name,
                    Id = team.Id
                });
            }

            return teamDtoList;
        }

        /// <inheritdoc/>
        public TeamDto UpdateTeam(TeamDto teamDto)
        {
            if (teamDto == null)
            {
                teamDto.Success = false;
                teamDto.Message = "Team is null or empty";
                return teamDto;
            }
            var team = _baseRepository.GetWhere(x => x.Id == teamDto.Id).FirstOrDefault();

            team.Name = teamDto.Name;
            team.CoachName = teamDto.CoachName;
            team.Country = teamDto.Country;
            team.FoundationDate = teamDto.FoundationDate;

            _baseRepository.Update(team);

            teamDto.Success = true;
            teamDto.Message = "Updated successfully";

            return teamDto;
        }
    }
}
