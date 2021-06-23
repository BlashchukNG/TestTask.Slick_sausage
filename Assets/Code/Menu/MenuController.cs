using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace testtask.sausage
{
    public class MenuController : MonoBehaviour
    {
        private void Start()
        {
            FindObjectOfType<Button>().onClick.AddListener(() => SceneManager.LoadScene(1));
        }
    }
}
