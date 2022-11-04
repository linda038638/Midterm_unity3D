using UnityEngine;

namespace Misun
{

    public class CameraConttroller : MonoBehaviour
    {
        [SerializeField]
        private Transform player;
        private float mouseX, mouseY; //X方向是左右移動，Y方向是上下移動
        [SerializeField, Header("滑鼠靈敏度")]
        private float controlSpeed;
        private float LimitRotation;

        private void Update()
        {
            CameraControl();

        }

        private void CameraControl()
        {
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * controlSpeed;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * controlSpeed;
            LimitRotation -= mouseY;
            LimitRotation = Mathf.Clamp(LimitRotation, -25f, 25f);
            player.Rotate(Vector3.up * mouseX);
            transform.localRotation = Quaternion.Euler(LimitRotation, 0, 0);
        }




    }
}


