using UnityEngine;
using TMPro;



//丟東西系統(包含子彈生成)
/// <summary>
/// 處理投擲物生成、投擲方向、投擲條件，也包刮投擲時產生的特效。
/// *使用射線方式完成投擲動作。
/// 官方文件： https://docs.unity.cn/cn/current/ScriptReference/Physics.Raycast.html
/// </summary>
namespace Misun
{
    public class Throwing : MonoBehaviour
    {

        #region Declare Varible & Component

        //投擲生成
        [SerializeField,Header("參考物")]
        private GameObject objectToThrow;             //物件(符咒)
        [SerializeField]
        private Transform spawnPoint, spawnRotation;  //物件生成點、生成方向
        private float damage = 10.0f;                 //符咒傷害(傳入值)

        //投擲方向
        [SerializeField]
        private Transform cam;                  //方向參考攝影機正前方
        [SerializeField, Header("投擲物理")]
        private float throwForce;               //設定丟出去的力道常數
        [SerializeField]
        private float throwUpwardForce;         //設定丟出去的力道常數

        //投擲條件
        [SerializeField ,Header("設定數量和冷卻時間")]
        private float throwCooldown;            //冷卻時間
        private bool readToThrow = true;        //投擲狀態
        [SerializeField]
        private int totalThrows;                //符咒總量
        [SerializeField]
        private TMP_Text printNumber;           //展示剩餘符咒量
        [SerializeField]
        private GameObject CanvansControl;      //調用結束畫面
             
        //投擲特效
        [SerializeField]
        private ParticleSystem magicParticle;   //丟的時候出現點光

        private void Awake()
        {
            printNumber.text = "符咒：" + totalThrows;
        }
        #endregion


        //主程式
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && readToThrow && totalThrows>=0)
            {
                readToThrow = false; 
                Throw();
                magicParticle.Play();

            }
            

        }


        #region Method

        //丟東西的方法
        private void Throw()
        {
            //生成要丟的物件、剛體元件
            GameObject bullet = Instantiate(objectToThrow, spawnPoint.position, spawnRotation.rotation); 
            Rigidbody  bulletRb = bullet.GetComponent<Rigidbody>();
            Vector3 forceDirection = cam.transform.forward;
            //射線，如果射線有與物體相交會傳true    
            RaycastHit hit;  
            if (Physics.Raycast(cam.position, cam.forward, out hit, 100.0f))            //Physics.Raycast(射線起點, 方向向量, 相交物(要宣告), 相交偵測範圍)
            {
                forceDirection = (hit.point - spawnPoint.position).normalized;          //要運動的方向向量 = (攝影機方向射到的點位置 - 子彈生成位置)的單位向量
                    
                EnemyDamage enemyDamage = hit.transform.GetComponent<EnemyDamage>();    //觸發敵人傷害類別，如果是敵人，會傳入符咒的傷害值
                if (enemyDamage != null)
                { enemyDamage.TakeDamage(damage); }
            }

            //加力量給剛體，剛體會運動
            Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
            bulletRb.AddForce(forceToAdd, ForceMode.Impulse);

            BulletCount();

            Invoke(nameof(ResetThrow), throwCooldown);
        }

        #region Else Method

        //子彈計數的方法
        private void BulletCount()
        {           
            totalThrows--;                                  //計數器-1
            printNumber.text = "符咒：" + totalThrows;       //更改數量

            if (totalThrows < 0)
            {
                CanvasCountrol canvas = CanvansControl.GetComponent<CanvasCountrol>();
                canvas.LostGame();
            }

        }

        //重設射擊狀態的方法
        private void ResetThrow()
        {
            readToThrow = true;
        }
        #endregion
        
        #endregion

    }
}





