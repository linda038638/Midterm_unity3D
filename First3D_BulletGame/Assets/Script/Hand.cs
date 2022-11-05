using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 射擊系統
/// https://www.youtube.com/watch?v=THnivyG0Mvo
/// https://www.youtube.com/watch?v=EwiUomzehKU simple
/// </summary>
namespace Misun
{
    public class Hand : MonoBehaviour
    {
        [Header("手的指向")]
        private float damage = 10.0f;
        private float range = 100.0f;
        public Camera fpsCam;

        /*
        public Transform bulletSpawnPoint;
        public GameObject bulletPrefab;
        public float bulletSpeed = 10;
        */

        [SerializeField]
        private ParticleSystem magicParticle;



        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                shoot();
                
                }
        }
    

        private void shoot()
        {
            magicParticle.Play();
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                print(hit.transform.name);
                
                //使用傷害類別
                 EnemyDamage enemyDamage = hit.transform.GetComponent<EnemyDamage>();
                 if (enemyDamage != null)
                 {
                            enemyDamage.TakeDamage(damage);
                 }



            }
                
        }
















    }
}





