using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Misun
{
    public class Hand : MonoBehaviour
    {
        private float damage = 10.0f;
        private float range = 100.0f;
        public Camera fpsCam;

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
                 EnemyDamage enemyDamage = hit.transform.GetComponent<EnemyDamage>();
                 if (enemyDamage != null)
                 {
                            enemyDamage.TakeDamage(damage);
                 }
            }
                
        }
















    }
}





