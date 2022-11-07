using UnityEngine;


//2.
/// <summary>
/// 關掉介紹畫面、並且打開控制介紹畫面
/// </summary>
namespace Misun
{
    public class OpenControl : MonoBehaviour
    {
        [SerializeField]
        private GameObject IntroPanel, ControlPanel;
        
        public void SwitchToControl()
        {
            IntroPanel.SetActive(false);
            ControlPanel.SetActive(true);

        }

    }

}

