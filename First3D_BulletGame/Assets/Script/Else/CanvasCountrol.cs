using UnityEngine;
using UnityEngine.UI;

//畫面控制腳本
/// <summary>
/// 1.贏的畫面
/// 2.輸的畫面
/// </summary>
namespace Misun
{
    public class CanvasCountrol : MonoBehaviour
    {

        [SerializeField]
        private GameObject Game_Pennel, Lost_Pennel, Win_Pennel;

        private void Awake()
        {
            Game_Pennel.SetActive(true);
            Lost_Pennel.SetActive(false);
            Win_Pennel.SetActive(false);
        }

        public void Update()
        {
           // Cursor.lockState = CursorLockMode.Confined;
        }
        public void LostGame()
        {
            Game_Pennel.SetActive(false);
            Lost_Pennel.SetActive(true);
            Cursor.visible = true;

        }

        public void WinGame()
        {
            Game_Pennel.SetActive(false);
            Win_Pennel.SetActive(true);
            Cursor.visible = true;
        }
    }
}