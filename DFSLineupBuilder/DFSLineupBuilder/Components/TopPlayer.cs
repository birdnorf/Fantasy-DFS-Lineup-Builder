using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player = DFSLineupBuilder.Player;

namespace DFSLineupBuilder.Components
{
    class TopPlayer
    {
        public static Player findTopPlayer(List<Player> listOfPlayers)
        {
            Player topPlayer = new Player();
            foreach(Player player in listOfPlayers)
            {
                if (player.avgPoints > topPlayer.avgPoints)
                    topPlayer = player;
                else
                    continue;
            }

            return topPlayer;
        }
    }
}
