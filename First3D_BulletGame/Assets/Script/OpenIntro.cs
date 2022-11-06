using UnityEngine;
using UnityEngine.SceneManagement;

namespace Misun
{
    public class OpenIntro : MonoBehaviour
    {

        public GameObject ButtonToIntro;
        public GameObject IntroPanel;
        /*
        private void Awake()
        {
            ButtonToIntro.SetActive(true);
            IntroPanel.SetActive(false);
        }
        */
        public void SwitchToIntro()
        {
            ButtonToIntro.SetActive(false);
            IntroPanel.SetActive(true);

        }


    }

}

