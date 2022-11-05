using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 敵人系統
/// 功能包含自動巡邏、跟蹤玩家、自動攻擊
/// 參考影片:https://www.youtube.com/watch?v=UjkSFoLxesw
/// </summary>
namespace Misun
{
    public class EnemyNav : MonoBehaviour
    {
        public NavMeshAgent agent;  //敵人物件
        public Transform player;
        public LayerMask whatIsGround, whatIsPlayer;

        //Patroling巡邏
        public Vector3 walkPoint;
        bool walkPointSet;
        public float walkPointRange;


        //Attacking
        public float timeBetweenAttack;
        bool alreadyAttacked;

        //States
        public float sightRange, attackRange;
        public bool playerInSightRange, playerInAttackRange;

        private void Awake()
        {
            player = GameObject.Find("Player").transform;
            agent = GetComponent<NavMeshAgent>(); //抓取敵人物件
        }

        private void Update()
        {

            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInSightRange && playerInAttackRange) AttackPlayer();

        }


        private void Patroling()
        {
            if (!walkPointSet) SearchWalkPoint();
            if (walkPointSet) agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //Walkpoint reached
            if( distanceToWalkPoint.magnitude <1.0f)
            {
                walkPointSet = false;
            }    
        }

        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.y + randomZ);
            if (Physics.Raycast(walkPoint, -transform.up, 2.0f, whatIsGround))
            {
                walkPointSet = true;
            }
        }
        private void ChasePlayer()
        {
            agent.SetDestination(player.position);

        }

        private void AttackPlayer()
        {
            //確保敵人不會動
            agent.SetDestination(transform.position);

            transform.LookAt(player);

            if(!alreadyAttacked)
            {

                alreadyAttacked = true;
                //Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }

                
                
        }

        private void ResetAttack()
        {
            alreadyAttacked = false;

        }


    }
}
