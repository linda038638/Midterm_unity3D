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


        public NavMeshAgent agent; //敵人物件
        private GameObject player;
        //public Transform player;   //玩家位置


        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            player = GameObject.Find("Player");
        }




        void Update()
        {
            agent.SetDestination(player.transform.position);
        }












    }

}
