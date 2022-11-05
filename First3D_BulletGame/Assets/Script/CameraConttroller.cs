using UnityEngine;
/// <summary>
/// 
/// 官方文件 https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
/// </summary>


namespace Misun
{

    public class CameraConttroller : MonoBehaviour
    {
        [SerializeField] 
        private Transform player;//玩家位置資訊
        private float mouseX, mouseY; //X方向是左右移動，Y方向是上下移動
        [SerializeField, Header("滑鼠靈敏度")]
        private float RLcontrolSpeed;
        [SerializeField]
        private float UDcontrolSpeed;
        private float LimitRotation;

        private void Update()
        {
           CameraControl();

        }

        private void CameraControl()
        {
            
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * RLcontrolSpeed;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * UDcontrolSpeed;
           

            LimitRotation -= mouseY;
            LimitRotation = Mathf.Clamp(LimitRotation, -90f, 90f);
           
            player.Rotate(Vector3.up * mouseX);
            
            transform.localRotation = Quaternion.Euler(LimitRotation, 0, 0);
        }
        



    }
}


