using UnityEngine;



//控制視角系統
/// <summary>
/// 利用轉動控制角色視角，用鼠標控制視角的方向。
/// 1.左右轉動用角色控制
/// 2.上下轉動用攝影機控制
/// 參考官方文件 https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
/// </summary>
namespace Misun
{

    public class Viewpoint : MonoBehaviour
    {
        #region Declare Varible & Component

        //自訂滑鼠靈敏度
        [SerializeField, Header("滑鼠靈敏度")]
        private float RlControlSpeed;
        [SerializeField]
        private float UdControlSpeed;

        //得到玩家位置資訊
        [SerializeField]
        private Transform cam;              //取得攝影機位置資訊

        //攝影機轉動
        private float mouseX, mouseY;          //X方向左右轉動，Y方向上下轉動，此變數儲存移動的量
        private float LimitRotation;           //限制轉動的量

        #endregion

        //主程式
        private void Update()
        {
            ViewpointControl();  //視角控制
        }

        #region Method

        //攝影機控制方法
        private void ViewpointControl()
        {
            //儲存轉動的量
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * RlControlSpeed;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * UdControlSpeed;

            //限制上下轉動的範圍，避免翻身
            LimitRotation -= mouseY;
            LimitRotation = Mathf.Clamp(LimitRotation, -70.0f, 70.0f);

            //轉動角色
            this.transform.Rotate(Vector3.up * mouseX);
            //轉動攝影機
            cam.localRotation = Quaternion.Euler(LimitRotation, 0, 0);

        }

        #endregion

    }
}


