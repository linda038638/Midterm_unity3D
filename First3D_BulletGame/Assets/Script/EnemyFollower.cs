using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Misun
{
    public class EnemyFollower : MonoBehaviour
    {


        public NavMeshAgent agent; //�ĤH����
        private GameObject player;
        //public Transform player;   //���a��m


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
