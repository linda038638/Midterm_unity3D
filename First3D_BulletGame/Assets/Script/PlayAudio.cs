using UnityEngine;

namespace Misun
{
    public class PlayAudio : MonoBehaviour
    {
        public AudioSource EnemyBfx;
        private void Start()
        {
            EnemyBfx = this.gameObject.GetComponent<AudioSource>();
        }

        
       protected void EnemyDieSound()
        {
            EnemyBfx.Play();
        }
       





    }
}

