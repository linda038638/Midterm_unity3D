using UnityEngine;

namespace Misun
{
    public class EnemyDamage : MonoBehaviour
    {

        //敵人狀態
        [SerializeField, Header("血量")]
        private float blood = 50.0f;
        protected bool isSealed = false;
        protected string WhoIsSeald = "";

        public void TakeDamage(float amount)
        {
            isSealed = true;
            WhoIsSeald = this.name;

            blood -= amount;
            if( blood <=0.0f)
            {
                Die();
            }
        }

        private void Die()
        {
            if (blood == 0.0f)
            {
                PlayAudio.EnemyDieSound();
            }
            Invoke(nameof(destroy), 1.0f);            
        }

        private void destroy()
        {
            Destroy(gameObject);
        }





    }
}

