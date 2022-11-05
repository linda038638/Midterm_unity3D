using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// �ĤH�۰ʸ���
///
/// Nevmesh https://github.com/Unity-Technologies/NavMeshComponents
/// �U��->�����Y->Assest->NavMeshComponents
/// �⤸��Ԫ�unity��Assest�Y�i�ϥ�
/// Instructor/// https://www.youtube.com/watch?v=dk9vYAtaH-0
/// </summary>
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
