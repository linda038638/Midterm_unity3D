using UnityEngine;


//攝影機控制系統
/// <summary>
/// 利用攝影機協助控制角色視角，作法為1.左右轉動用角色控制2.上下轉動用攝影機控制
/// 把攝影機當作頭，用鼠標轉動攝影機控制頭的方向
/// 參考官方文件 https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
/// </summary>
namespace Misun
{

    public class CameraConttroller : MonoBehaviour
    {
        #region Declare Varible & Component

        //自訂滑鼠靈敏度
        [SerializeField, Header("滑鼠靈敏度")]
        private float RLcontrolSpeed;
        [SerializeField]
        private float UDcontrolSpeed;
        
        //得到玩家位置資訊
        [SerializeField]
        private Transform player;              //取得角色位置資訊

        //攝影機轉動
        private float mouseX, mouseY;          //X方向左右轉動，Y方向上下轉動，此變數儲存移動的量
        private float LimitRotation;           //限制轉動的量

        #endregion

        //主程式
        private void Update()
        {
           CameraControl();

        }

        #region Method

        //攝影機控制方法
        private void CameraControl()
        {
            //儲存轉動的量
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * RLcontrolSpeed;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * UDcontrolSpeed;

            //限制上下轉動的範圍，避免翻身
            LimitRotation -= mouseY;
            LimitRotation = Mathf.Clamp(LimitRotation, -70.0f, 70.0f);

            //控制角色左右轉動
            player.Rotate(Vector3.up * mouseX);
            //控制攝影機上下轉動
            transform.localRotation = Quaternion.Euler(LimitRotation, 0, 0);
        }

        #endregion


    }
}


