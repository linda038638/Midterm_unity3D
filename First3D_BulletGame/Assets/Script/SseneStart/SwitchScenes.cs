using UnityEngine;
using UnityEngine.SceneManagement;


//3.
/// <summary>
/// 載入遊戲場景
/// </summary>
namespace Misun
{
    public class SwitchScenes : MonoBehaviour
    {
        public void SwitchScenesToGame()
        {
            print("do");
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

    }

}

