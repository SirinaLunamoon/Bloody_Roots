using UnityEngine;
using UnityEngine.SceneManagement;

namespace Roots.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.ExitPlaymode();
                #endif
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene("TestScene");
            }
        }
    }
}