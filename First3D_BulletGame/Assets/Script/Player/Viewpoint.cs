using UnityEngine;



//��������t��
/// <summary>
/// �Q����ʱ��������A�ι��б����������V�C
/// 1.���k��ʥΨ��ⱱ��
/// 2.�W�U��ʥ���v������
/// �Ѧҩx���� https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
/// </summary>
namespace Misun
{

    public class Viewpoint : MonoBehaviour
    {
        #region Declare Varible & Component

        //�ۭq�ƹ��F�ӫ�
        [SerializeField, Header("�ƹ��F�ӫ�")]
        private float RlControlSpeed;
        [SerializeField]
        private float UdControlSpeed;

        //�o�쪱�a��m��T
        [SerializeField]
        private Transform cam;              //���o��v����m��T

        //��v�����
        private float mouseX, mouseY;          //X��V���k��ʡAY��V�W�U��ʡA���ܼ��x�s���ʪ��q
        private float LimitRotation;           //������ʪ��q

        #endregion

        //�D�{��
        private void Update()
        {
            ViewpointControl();  //��������
        }

        #region Method

        //��v�������k
        private void ViewpointControl()
        {
            //�x�s��ʪ��q
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * RlControlSpeed;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * UdControlSpeed;

            //����W�U��ʪ��d��A�קK½��
            LimitRotation -= mouseY;
            LimitRotation = Mathf.Clamp(LimitRotation, -70.0f, 70.0f);

            //��ʨ���
            this.transform.Rotate(Vector3.up * mouseX);
            //�����v��
            cam.localRotation = Quaternion.Euler(LimitRotation, 0, 0);

        }

        #endregion

    }
}


