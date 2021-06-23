using UnityEngine;

namespace testtask.sausage
{
    [CreateAssetMenu(fileName = "dataGame", menuName = "Data/dataGame")]
    public sealed class GameData :
        ScriptableObject
    {
        [Header("came version")]
        public string CurrentGameVersion;
        [Header("root paths")]
        public string RootPrefabs;
        public string RootDatas;
        [Header("ui controller")]
        public string RootUIController;
        public string PrfMainCanvas;
        public string PrfGameVersion;
        public string PrfEndGame;
        [Header("player controller")]
        public string TagPlayerStartPosition;
        public string RootPlayerController;
        public string PrfPlayer;
        public string PrfPoint;
        public string DataPlayer;        
        public string DataTrajectory;        


        #region InputController

        #endregion
              
        #region PlayerController

        public Transform GetPrfPlayer { get => Load<Transform>($"{RootPrefabs}/{RootPlayerController}/{PrfPlayer}"); }
        public Transform GetPrfPoint { get => Load<Transform>($"{RootPrefabs}/{RootPlayerController}/{PrfPoint}"); }
        public PlayerData GetDataPlayer { get => Load<PlayerData>($"{RootDatas}/{RootPlayerController}/{DataPlayer}"); }
        public TrajectoryData GetDataTrajectory { get => Load<TrajectoryData>($"{RootDatas}/{RootPlayerController}/{DataTrajectory}"); }

        #endregion

        #region UIController

        public Transform GetPrfMainCanvas { get => Load<Transform>($"{RootPrefabs}/{RootUIController}/{PrfMainCanvas}"); }
        public Transform GetPrfGameVersion { get => Load<Transform>($"{RootPrefabs}/{RootUIController}/{PrfGameVersion}"); }
        public Transform GetPrfEndGame { get => Load<Transform>($"{RootPrefabs}/{RootUIController}/{PrfEndGame}"); }

        #endregion


        public T Load<T>(string path) where T : Object
        {
            var file = Resources.Load<T>(path);
            if (file == null)
                throw new System.NullReferenceException($"file not found in path: Resources/{path}");
            return file;
        }
    }
}
