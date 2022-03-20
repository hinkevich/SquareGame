using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class Scene
    {

        public GameObject UpBorder;
        public GameObject DownBorder;
        public GameObject PlayerOneInfo;
        public GameObject PlayerTwoInfo;
        public GameObject VerticalBorderLeft;
        public GameObject VerticalBorderRight;
        private static Scene _scene;
        public GameSettings _gameSetting;
        public List<GameObject> SquareList;
        private Scene()
        {

        }
        public Scene(GameSettings gameSettings)
        {
            // add information about player One:

            _gameSetting = gameSettings;
            GameObjectPlace gameObjectPlacePlayerOne = new GameObjectPlace(_gameSetting.PlayerOneInformationX, _gameSetting.PlayerOneInformationY);
            PlayerOneInfo = new PlayerInfoFactory(_gameSetting).GetGameObject(gameObjectPlacePlayerOne);

            // add information about player One:

            GameObjectPlace gameObjectPlacePlayerTwo = new GameObjectPlace(_gameSetting.PlayerTwoInformationX, _gameSetting.PlayerTwoInformationY);

            PlayerTwoInfo = new PlayerInfoFactory(_gameSetting).GetGameObject(gameObjectPlacePlayerTwo);

            // add left border:
            GameObjectPlace leftBorder = new GameObjectPlace(_gameSetting.VerticalLeftboarderX, _gameSetting.VerticalLeftboarderY);

            VerticalBorderLeft = new VerticalBorderObject(_gameSetting.verticalBorder, leftBorder, GameObjectType.LeftBorderObject);

            // add Right border

            GameObjectPlace rightBorder = new GameObjectPlace(_gameSetting.VerticalRightboarderX, _gameSetting.VerticalLeftboarderY);

            VerticalBorderRight = new VerticalBorderObject(_gameSetting.verticalBorder, rightBorder, GameObjectType.RightBorderObject);

            // add Up border:
            GameObjectPlace upBorder = new GameObjectPlace(_gameSetting.upHorizontalBorderX, _gameSetting.upHorizontalBorderY);

            UpBorder = new HorizontalBordder(_gameSetting.horizontalBorder, upBorder, GameObjectType.UpBorderObject);

            // add Down border:
            GameObjectPlace downBoarder = new GameObjectPlace(_gameSetting.downHirizontalX, _gameSetting.downHirizontalY);

            DownBorder = new HorizontalBordder(_gameSetting.horizontalBorder, downBoarder, GameObjectType.DownBorderObject);

            // add list

            SquareList = new List<GameObject>();
        }

        public static Scene GetScene(GameSettings gameSettings)
        {
            if (_scene == null)
            {
                _scene = new Scene(gameSettings);
            }
            return _scene;
        }
    }
}
