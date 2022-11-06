using UnityEngine;
/// <summary>
/// 關掉介紹畫面、並且打開控制介紹畫面
/// </summary>
namespace Misun
{
    public class OpenControl : MonoBehaviour
    {

        public GameObject IntroPanel;
        public GameObject ControlPanel;
        /*
        private void Awake()
        {
            ButtonToIntro.SetActive(true);
            IntroPanel.SetActive(false);
        }
        */
        public void SwitchToControl()
        {
            IntroPanel.SetActive(false);
            ControlPanel.SetActive(true);

        }


    }

}

