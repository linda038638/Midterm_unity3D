using UnityEngine;

namespace Misun
{
    public class EnemyDamage : MonoBehaviour
    {

        public float blood = 50.0f;
        public void TakeDamage(float amount)
        {
            blood -= amount;
            if( blood <=0.0f)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);

        }







    }
}

