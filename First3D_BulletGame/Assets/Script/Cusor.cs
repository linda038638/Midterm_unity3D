using UnityEngine;

//���б���}��
/// <summary>
/// 1.�w�B�z����������
/// 2.���Ф��i�W�X����
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
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}