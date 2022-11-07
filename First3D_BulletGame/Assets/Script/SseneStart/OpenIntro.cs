using UnityEngine;


//1.
/// <summary>
/// 關掉開始畫面、並且打開介紹畫面
/// </summary>
namespace Misun
{
    public class OpenIntro : MonoBehaviour
    {
        [SerializeField]
        private GameObject ButtonOpenIntro, IntroPanel;

        public void SwitchToIntro()
        {
            ButtonOpenIntro.SetActive(false);
            IntroPanel.SetActive(true);

        }

    }

}

