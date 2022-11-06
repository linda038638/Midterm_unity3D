using UnityEngine;
/// <summary>
/// 關掉開始畫面、並且打開介紹畫面
/// </summary>
namespace Misun
{
    public class OpenIntro : MonoBehaviour
    {

        public GameObject ButtonOpenIntro;
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
            ButtonOpenIntro.SetActive(false);
            IntroPanel.SetActive(true);

        }


    }

}

