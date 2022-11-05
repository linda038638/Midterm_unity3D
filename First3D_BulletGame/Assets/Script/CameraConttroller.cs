using UnityEngine;
/// <summary>
/// 
/// �x���� https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
/// </summary>


namespace Misun
{

    public class CameraConttroller : MonoBehaviour
    {
        [SerializeField] 
        private Transform player;//���a��m��T
        private float mouseX, mouseY; //X��V�O���k���ʡAY��V�O�W�U����
        [SerializeField, Header("�ƹ��F�ӫ�")]
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


