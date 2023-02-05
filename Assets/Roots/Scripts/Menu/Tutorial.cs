using UnityEngine;
using UnityEngine.SceneManagement;

namespace Roots.Menu
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private GameObject[] _tutorialScreens;

        public void Progress()
        {
            Debug.Log("Progress");
            foreach (var ts in _tutorialScreens)
            {
                if (ts.activeSelf == false)
                {
                    ts.SetActive(true);
                    return;
                }
            }
            SceneManager.LoadScene("TestScene");
        }
    }
}