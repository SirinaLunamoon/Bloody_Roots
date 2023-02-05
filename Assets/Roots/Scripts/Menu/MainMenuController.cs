using UnityEngine;

namespace Roots.Menu
{
    public class MainMenuController : MonoBehaviour
    {

        [SerializeField] private Tutorial _tutorial;
        
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
                _tutorial.Progress();
            }
        }
    }
}