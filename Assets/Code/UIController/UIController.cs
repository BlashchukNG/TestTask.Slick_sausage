using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace testtask.sausage
{
    public sealed class UIController :
        IController
    {
        public Transform MainCanvas { get; set; }

        private Transform _endGame;

        public UIController(Transform mainCanvas, Transform endGame)
        {
            MainCanvas = mainCanvas;
            _endGame = endGame;
            _endGame.gameObject.SetActive(false);
            _endGame.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
                SceneManager.LoadScene(1));
        }

        public void EndGame()
        {
            _endGame.gameObject.SetActive(true);
        }
    }
}

