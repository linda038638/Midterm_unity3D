using UnityEngine;

namespace Misun
{
    public class EnemyDamage : PlayAudio
    {
        private void Start()
        {
        }

        public float blood = 50.0f;
        public void TakeDamage(float amount)
        {
            EnemyFollower.isSealed = true;
            EnemyFollower.WhoIsSeald = this.name;
            Debug.Log("封印" + this.name);
            blood -= amount;
            if( blood <=0.0f)
            {
                Die();
            }
        }

        private void Die()
        {
            if(blood ==0.0f) EnemyDieSound();
            Invoke(nameof(destroy), 2.0f);
            
        }

        private void destroy()
        {
            Destroy(gameObject);
        }





    }
}

