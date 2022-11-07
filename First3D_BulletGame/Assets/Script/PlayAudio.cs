using UnityEngine;



//敵人升天音樂
/// <summary>
/// 播放敵人升天音樂，設置成靜態變數/方法
/// </summary>
namespace Misun
{
    public class PlayAudio : MonoBehaviour
    {
        public static AudioSource EnemyBfx;

        private void Start()
        {
            EnemyBfx = this.gameObject.GetComponent<AudioSource>();
        }
        
        public static void EnemyDieSound()
        {
            PlayAudio.EnemyBfx.Play();
        }
       
    }
}

