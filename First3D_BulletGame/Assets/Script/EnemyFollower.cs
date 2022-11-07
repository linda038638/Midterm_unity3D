using UnityEngine;
using UnityEngine.AI;



//敵人巡邏與追蹤系統
/// <summary>
/// 套入AI，讓敵人巡邏與自動追蹤，使用
/// Nevmesh套件 https://github.com/Unity-Technologies/NavMeshComponents ，
/// 使用方法：下載->解壓縮->Assest->NavMeshComponents
/// 把元件拉進unity的Assest即可使用
/// Renference https://www.youtube.com/watch?v=dk9vYAtaH-0
/// </summary>
namespace Misun
{

    public class EnemyFollower : EnemyDamage
    {

        #region Declare Varible & Component
                
        //敵人物件
        private NavMeshAgent agent;         //要裝Nav Mesh元件
        
        //追蹤物件
        private Transform player;           //找角色位置

        //判定追蹤
        public LayerMask  whatIsPlayer;               //圖層含有角色本人、子彈
        public float sightRange;                      //敵人視線範圍
        private bool playerInSightRange = false;      //敵人是否看到角色

        //巡邏參考點
        private Vector3 patrolingPathPoint;           //巡邏參考點
        private Vector3 CenterPoint;                  //地圖中心(巡邏圍繞著這個點，避免跑太遠)

        //調用元件
        void Start()
        {
            agent = this.GetComponent<NavMeshAgent>();
            player = GameObject.Find("Player").transform;
            CenterPoint = new Vector3(306.0f, -129.9f, 2.1f);
            InvokeRepeating(nameof(SetPathPoint), 0.0f,5.0f);   //重複更新巡邏點
        }

        #endregion
      

        //主程式
        void Update()
        {            
            //檢查是否被封印
            if (isSealed && agent.name == WhoIsSeald)
            {   
                freeze();     //是的話凍結
            }else
            {
                unfreeze();   //否的話行動
            }
        }

        #region Freeze Method

        //凍結(封印)
        private void freeze()
        {
            agent.SetDestination(transform.position);          //停止追角色
            Invoke(nameof(resetWhoIsSealed), 4.0f);            //封印維持幾秒後解除封印
        }

        //解除封印
        private void resetWhoIsSealed()
        {
            isSealed = true;
            WhoIsSeald = "";
        }

        #endregion

        #region Unfreeze Method

        private void unfreeze()
        {
            //判定角色是否在敵人視線範圍內  CheckSphere(檢查點圓心,檢查半徑,判定物品的圖層) ps該圖層可忽略碰撞，ex子彈
            if (Physics.CheckSphere(transform.position, sightRange, whatIsPlayer))
            { playerInSightRange = true; }           //沒有else，一旦偵測到就會一直追下去囉~~
            //看到就追，沒看到就巡邏
            if (playerInSightRange)  following();    
            if (!playerInSightRange) Patroling();    
        }

        //追蹤
        private void following()
        {
            agent.SetDestination(player.transform.position);   //追蹤角色
        }

        //巡邏
        private void Patroling()
        {
            agent.SetDestination(patrolingPathPoint);
        }

        //更新巡邏位置
        private void SetPathPoint()
        {
            patrolingPathPoint = new Vector3(Random.Range(-200.0f, 200.0f), 0.0f, Random.Range(-200.0f, 200.0f));
            patrolingPathPoint = patrolingPathPoint + this.transform.position;
        }

        #endregion

    }

}
