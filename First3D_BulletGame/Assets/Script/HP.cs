using UnityEngine;
using UnityEngine.UI;



//血量
/// <summary>
/// 處理玩家血量被扣，顯示在UI上，並寫處理遊戲結束條件之一(死掉)
/// /// </summary>
namespace Misun
{

    public class HP : MonoBehaviour
    {

        #region Declare Varible & Component

        [SerializeField]
        private Slider hpSlider;        //血條
        private float clock = 0;        //計時器
        private float duration = 0;     //緩衝時間

        #endregion

         void Update()
        {
            clock += Time.deltaTime;
            if(EnemyFollower.playerIsCatch && clock > duration) //被抓到跟時間到時扣血
            {
                bleed();
                duration = clock + 0.5f;
            }
        }

        #region Method

        public void bleed()
        {  
            hpSlider.value -= 2.0f;
            if(hpSlider.value <= 0)
            {
                print("You,re Die!");
            }
        }

        #endregion


    }

}


