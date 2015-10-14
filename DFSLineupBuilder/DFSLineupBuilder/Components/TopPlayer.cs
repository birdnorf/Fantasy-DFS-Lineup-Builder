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


            //Get Top Center
            foreach (Player center in listOfPlayers.FindAll(i => i.position == "C"))
            {
                if (center.avgPoints > topCenter.avgPoints)
                    topCenter = center;
                else
                    continue;
            }

            topPlayers.Add(topCenter);

            //Get Top Right Winger
            foreach (Player rightWing in listOfPlayers.FindAll(i => i.position == "RW"))
            {
                if (rightWing.avgPoints > topRightWing.avgPoints)
                    topRightWing = rightWing;
                else
                    continue;
            }

            topPlayers.Add(topRightWing);

            //Get Top Left Winger
            foreach (Player leftWing in listOfPlayers.FindAll(i => i.position == "LW"))
            {
                if (leftWing.avgPoints > topLeftWing.avgPoints)
                    topLeftWing = leftWing;
                else
                    continue;
            }

            topPlayers.Add(topLeftWing);
            //Get Top Defender
            foreach (Player defense in listOfPlayers.FindAll(i => i.position == "D"))
            {
                if (defense.avgPoints > topDefense.avgPoints)
                    topDefense = defense;
                else
                    continue;
            }

            topPlayers.Add(topDefense);
            //Get Top Goalie
            foreach (Player goalie in listOfPlayers.FindAll(i => i.position == "G"))
            {
                if (goalie.avgPoints > topGoalie.avgPoints)
                    topGoalie = goalie;
                else
                    continue;
            }

            topPlayers.Add(topGoalie);



            return topPlayers;
        }
    }
}
