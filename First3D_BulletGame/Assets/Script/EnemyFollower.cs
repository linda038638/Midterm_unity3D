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

        public static bool isSealed = false;
        public static string  WhoIsSeald;

        public NavMeshAgent agent; //�ĤH����
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
            { print("�ĤH�W�r�@��!"); }

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
