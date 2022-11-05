using UnityEngine;

namespace Misun
{
    public class EnemyDamage : MonoBehaviour
    {

        public float blood = 50.0f;
        public void TakeDamage(float amount)
        {
            EnemyFollower.isSealed = true;
            EnemyFollower.WhoIsSeald = this.name;

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

