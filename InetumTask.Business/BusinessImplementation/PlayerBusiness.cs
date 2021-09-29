using InetumTask.Business.BusinessInterface;
using InetumTask.DAL.BaseRepository;
using InetumTask.DAL.Models;
using InetumTask.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InetumTask.Business.BusinessImplementation
{
    public class PlayerBusiness : IPlayerBusiness
    {
        private readonly IBaseRepository<Player> _baseRepository;
        public PlayerBusiness(IBaseRepository<Player> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <inheritdoc/>
        public bool AddPlayersList(IEnumerable<PlayerDto> playerListDtos)
        {
            List<Player> playersList = new List<Player>();

            foreach (var player in playerListDtos)
            {
                playersList.Add(new Player
                {
                    Name = player.Name,
                    Image = player.Image,
                    Nationality = player.Nationality,
                    TeamId = player.TeamId
                });
            }
            _baseRepository.AddList(playersList);
            return true;
        }

        /// <inheritdoc/>
        public bool DeletePlayerById(int Id)
        {
            if (Id == 0)
            {
                return false;
            }
            var player = _baseRepository.GetWhere(x => x.Id == Id && x.IsDeleted == false).FirstOrDefault();
            player.IsDeleted = true;
            _baseRepository.Update(player);
            return true;
        }

        /// <inheritdoc/>
        public bool DeletePlayersByTeamId(int TeamId)
        {
            try
            {
                if (TeamId == 0)
                {
                    return false;
                }

                var playersList = _baseRepository.GetWhere(x => x.TeamId == TeamId && x.IsDeleted == false).ToList();

                foreach (var player in playersList)
                {
                    player.IsDeleted = true;
                    _baseRepository.Update(player);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <inheritdoc/>
        public IEnumerable<PlayerDto> GetPlayersListByTeamId(int TeamId)
        {
            var PlayersList = _baseRepository.GetWhere(x => x.TeamId == TeamId && x.IsDeleted == false);

            List<PlayerDto> PlayerList = new List<PlayerDto>();

            foreach (var player in PlayersList)
            {
                PlayerList.Add(new PlayerDto
                {
                    Id = player.Id,
                    TeamId = player.TeamId,
                    Nationality = player.Nationality,
                    Image = player.Image,
                    Name = player.Name
                });
            }
            return PlayerList;
        }
    }
}
