using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class PlayerInfoFactory : GameObjectFactory
    {
        public PlayerInfoFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObject playerInfo = new PlayerInfo(GameSettings.InfoAboutPlayerChar ,gameObjectPlace, GameObjectType.PlayerInfo, GameSettings.PlayerQuantityOfMove, GameSettings.PlayerQuantityOfAttempts, "PlayerOne");
            
            return playerInfo;
        }
    }
}
