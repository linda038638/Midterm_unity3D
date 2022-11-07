using UnityEngine;

//符咒碰撞事件
/// <summary>
/// 子彈預製物碰撞後停止、停留與消失
/// </summary>
namespace Misun
{

    public class Bullet : MonoBehaviour
    {

        #region Get Component

        private Rigidbody rb;
        private BoxCollider bulletColl;

        private void Start()
        {
            bulletColl = this.GetComponent<BoxCollider>();
            rb = this.GetComponent<Rigidbody>();
        }

        #endregion
        
        //當子彈碰撞到物體時，停留一秒後消失
        private void OnCollisionEnter(Collision collision)
        {
            
            Stop();                               //停止移動
            Invoke(nameof(bulletDestroy), 1.0f);  //延遲一秒後執行破壞物件

        }

        #region Method

        //停止子彈
        private void Stop()
        {
            rb.Sleep();
            //Debug.Log("子彈停止");
        }

        //破壞子彈
        private void bulletDestroy()
        {
            Destroy(this.gameObject);
        }

        #endregion        

    }
}



