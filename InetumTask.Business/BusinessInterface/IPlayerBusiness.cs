using InetumTask.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace InetumTask.Business.BusinessInterface
{
    public interface IPlayerBusiness
    {
        /// <summary>
        /// Get list of all players for specific team by team id
        /// </summary>
        /// <param name="TeamId"><see cref="TeamId"/></param>
        /// <returns></returns>
        IEnumerable<PlayerDto> GetPlayersListByTeamId(int TeamId);

        /// <summary>
        /// Delete all players by for a specific team by team id
        /// </summary>
        /// <param name="TeamId"><see cref="TeamId"/></param>
        /// <returns></returns>
        bool DeletePlayersByTeamId(int TeamId);

        /// <summary>
        /// Delete one player by id
        /// </summary>
        /// <param name="Id"><see cref="Id"/></param>
        /// <returns></returns>
        bool DeletePlayerById(int Id);

        /// <summary>
        /// Add list of players
        /// </summary>
        /// <param name="playerListDtos"><see cref="playerListDtos"/></param>
        /// <returns></returns>
        bool AddPlayersList(IEnumerable<PlayerDto> playerListDtos);
    }
}
