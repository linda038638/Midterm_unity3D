using UnityEngine;
using UnityEngine.UI;



//��q
/// <summary>
/// �B�z���a��q�Q���A��ܦbUI�W�A�üg�B�z�C���������󤧤@(����)
/// /// </summary>
namespace Misun
{

    public class HP : MonoBehaviour
    {

        #region Declare Varible & Component

        [SerializeField]
        private Slider hpSlider;        //���
        private float clock = 0;        //�p�ɾ�
        private float duration = 0;     //�w�Įɶ�

        #endregion

         void Update()
        {
            clock += Time.deltaTime;
            if(EnemyFollower.playerIsCatch && clock > duration) //�Q����ɶ���ɦ���
            {
                bleed();
                duration = clock + 0.5f;
            }
        }

        #region Method

        public void bleed()
        {  
            hpSlider.value -= 2.0f;
            if(hpSlider.value <= 0)
            {
                print("You,re Die!");
            }
        }

        #endregion


    }

}


