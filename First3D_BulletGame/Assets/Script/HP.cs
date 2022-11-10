using UnityEngine;
using UnityEngine.UI;
using TMPro;



//血量和通關處理
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

        public static bool IsplayerCatch = false;     //判斷是否抓到敵人,HP腳本檢查
        public static int DestroyedEnemyCounter;    
        [SerializeField]
        private TMP_Text printEnemyNumber;           //展示剩餘符咒量

        private void Awake()
        {
            DestroyedEnemyCounter = 4;                  //敵人總量
            printEnemyNumber.text = "妖靈：" + DestroyedEnemyCounter;
        }
        #endregion

        void Update()
        {
            printEnemyNumber.text = "妖靈：" + DestroyedEnemyCounter;
            clock += Time.deltaTime;
            if (IsplayerCatch)
            {
                IsplayerCatch = false;
                if (clock > duration) //被抓到跟時間到時扣血
                {
                    bleed();          //該流血囉
                    duration = clock + 0.5f;
                }
            }
            if(DestroyedEnemyCounter == 0)  ///判斷通關條件
            {
                CanvasCountrol canvas = this.GetComponent<CanvasCountrol>();
                canvas.WinGame();
            }
                
                
        }

        #region Method

        public void bleed()
        {
            hpSlider.value -= 2.0f;
            if(hpSlider.value <= 0)
            {
                CanvasCountrol canvas = this.GetComponent<CanvasCountrol>();
                canvas.LostGame();
            }
            
        }

        #endregion


    }

}


