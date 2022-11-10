using UnityEngine;

//鼠標控制腳本
/// <summary>
/// 1.預處理時關閉鼠標
/// 2.鼠標不可超出視窗
/// </summary>
namespace Misun
{
    public class Cusor : MonoBehaviour
    {
        void Awake()
        {
            Cursor.visible = false;
        }

        void Update()
        {
            Cursor.lockState = CursorLockMode.Locked;
            print(CursorLockMode.Locked);
        }
    }
}