using UnityEngine;



//敵人傷害方法
/// <summary>
/// 接收傷害訊息後，處理傷害運作的方法。主要包含：
/// 1.封印狀態
/// 2.血量
/// 3.播放音效
/// </summary>
namespace Misun
{
    public class EnemyDamage : MonoBehaviour
    {

        #region Declare Varible & Component

        [Header("血量")]
        private float blood = 50.0f;　　　　 //血量
        protected bool isSealed = false;    //封印狀態
        protected string WhoIsSeald = "";   //誰被封印

        #endregion
        
        //接收傷害後的處理方法
        public void TakeDamage(float amount)
        {
            //先封印
            isSealed = true;
            WhoIsSeald = this.name;

            //扣血量
            blood -= amount;
            if( blood <=0.0f)
            {
                Die();
            }
        }

        #region Else Method

        //死掉
        private void Die()
        {
            if (blood == 0.0f)
            {
                PlayAudio.EnemyDieSound();
            }
            Invoke(nameof(destroy), 1.0f);            
        }

        //破壞
        private void destroy()
        {
            Destroy(gameObject);
            HP.DestroyedEnemyCounter--;
        }

        #endregion
        
    }
}

