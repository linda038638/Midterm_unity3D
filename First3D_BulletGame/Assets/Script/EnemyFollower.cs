using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
