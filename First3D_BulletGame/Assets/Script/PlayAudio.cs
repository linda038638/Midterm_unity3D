using UnityEngine;



//�ĤH�ɤѭ���
/// <summary>
/// ����ĤH�ɤѭ��֡A�]�m���R�A�ܼ�/��k
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

