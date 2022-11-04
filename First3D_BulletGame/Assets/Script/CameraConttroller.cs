using UnityEngine;

namespace Misun
{

    public class CameraConttroller : MonoBehaviour
    {
        [SerializeField]
        private Transform player;
        private float mouseX, mouseY; //X��V�O���k���ʡAY��V�O�W�U����
        [SerializeField, Header("�ƹ��F�ӫ�")]
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


