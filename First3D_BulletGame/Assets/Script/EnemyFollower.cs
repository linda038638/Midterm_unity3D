using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 敵人自動跟蹤
///
/// Nevmesh https://github.com/Unity-Technologies/NavMeshComponents
/// 下載->解壓縮->Assest->NavMeshComponents
/// 把元件拉近unity的Assest即可使用
/// Instructor/// https://www.youtube.com/watch?v=dk9vYAtaH-0
/// </summary>
namespace Misun
{
    public class EnemyFollower : MonoBehaviour
    {

        public static bool isSealed = false;
        public static string  WhoIsSeald;

        public NavMeshAgent agent; //敵人物件
        private GameObject player;

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            player = GameObject.Find("Player");
            Debug.Log("agent.name is " + agent.name);
            
        }



        void Update()
        {
            if(agent.name == WhoIsSeald)
            { print("敵人名字一樣!"); }

            if (isSealed && agent.name == WhoIsSeald)
            {
                agent.SetDestination(this.transform.position);

            }
            else
            {
                
                agent.SetDestination(player.transform.position);
            }

        }











    }

}
