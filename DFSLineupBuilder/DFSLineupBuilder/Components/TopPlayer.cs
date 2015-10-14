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

        public static List<Player> findTopPlayers(List<Player> listOfPlayers)
        {
            Player topCenter = new Player();
            Player topRightWing = new Player();
            Player topLeftWing = new Player();
            Player topDefense = new Player();
            Player topGoalie = new Player();

            List<Player> topPlayers = new List<Player>();

            //TODO CHANGE TO SWITCH STATEMENT FOR BETTER PERFORMANCE

            foreach(Player player in listOfPlayers)
            {
                switch (player.position)
                {
                    case "C":
                        if (player.avgPoints > topCenter.avgPoints)
                            topCenter = player;
                        continue;
                    case "RW":
                        if (player.avgPoints > topRightWing.avgPoints)
                            topRightWing = player;
                        continue;
                    case "LW":
                        if (player.avgPoints > topLeftWing.avgPoints)
                            topLeftWing = player;
                        continue;
                    case "D":
                        if (player.avgPoints > topDefense.avgPoints)
                            topDefense = player;
                        continue;
                    case "G":
                        if (player.avgPoints > topGoalie.avgPoints)
                            topGoalie = player;
                        continue;
                    default:
                        continue;
                }
            }

            topPlayers.Add(topCenter);
            topPlayers.Add(topRightWing);
            topPlayers.Add(topLeftWing);
            topPlayers.Add(topDefense);
            topPlayers.Add(topGoalie);

            return topPlayers;
        }
    }
}
