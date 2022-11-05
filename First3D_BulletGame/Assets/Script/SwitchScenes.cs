using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Misun
{
    public class SwitchScenes : MonoBehaviour
    {
        public void isSwitchScenes()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

    }

}

