using UnityEngine;
using UnityEngine.SceneManagement;

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

