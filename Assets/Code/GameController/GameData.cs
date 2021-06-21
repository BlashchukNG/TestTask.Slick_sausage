using UnityEngine;

namespace gig.fps
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
        [Header("player controller")]
        public string TagPlayerStartPosition;
        public string RootPlayerController;
        public string PrfPlayer;

        #region UIController

        public Transform GetPrfMainCanvas { get => Load<Transform>($"{RootPrefabs}/{RootUIController}/{PrfMainCanvas}"); }
        public Transform GetPrfGameVersion { get => Load<Transform>($"{RootPrefabs}/{RootUIController}/{PrfGameVersion}"); }

        #endregion

        #region PlayerController

        public PlayerView GetPrfPlayer { get => Load<PlayerView>($"{RootPrefabs}/{RootPlayerController}/{PrfPlayer}"); }

        #endregion

        public T Load<T>(string path) where T : Object
        {
            var file = Resources.Load<T>(path);
            if (file == null) throw new System.NullReferenceException($"file not found in path: Resources/{path}");
            return file;
        }
    }
}
