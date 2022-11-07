using UnityEngine;



//移動系統
/// <summary>
/// 1.角色移動，輸入wasd的位移
/// 2.角色跳躍，輸入空白鍵，不可連續跳躍需，檢測是否為地面
/// 3.走路聲音，播放移動時的腳步聲
/// </summary>
namespace Misun
{   

    public class Movement : MonoBehaviour
    {

        #region Declare Varible & Component

        //元件
        private CharacterController Player;               //角色控制元件
        private AudioSource WalkingSound;                 //聲音元件

        //移動
        [SerializeField, Header("速度設定")]
        private float moveSpeed;                          //移動速度常數
        private float horizontalMove, verticalMove;       //垂直與水平變數，儲存移動的量
        private Vector3 vecMovement;                      //移動方法使用的位移向量

        //跳躍
        [SerializeField]
        private float jumpSpeed;                          //跳躍速度常數
        private float grivaty = 9.8f;                     //跳躍用的重力
        private Vector3 velocity;                         //移動方法使用的位移向量，只儲存跳躍的變數(y軸)
        
        //確認地板
        [SerializeField, Header("偵測地面")]
        private Transform groundCheck;                    //偵測地板的空物件座標
        private float checkRadius = 0.4f;                 //偵測範圍
        [SerializeField]
        private LayerMask whatIsGround;                   //選地版圖層
        private bool isGround;                            //儲存接觸狀態

        //調用元件
        private void Awake()
        {
            Player = this.GetComponent<CharacterController>(); 
            WalkingSound = this.GetComponent<AudioSource>();   
        }

        #endregion

        //主程式
        private void Update()
        {
            CheackIsGround();         //檢查是否位於地面
            movement();               //移動方法
            PlayWalkingSound();       //播放腳步聲

        }

        #region Method

        //移動方法
        private void movement()
        {
            //移動
            horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            verticalMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            vecMovement = transform.forward * verticalMove + transform.right * horizontalMove;
            Player.Move(vecMovement);


            //跳躍
            if (Input.GetButtonDown("Jump") && isGround) //在地面才可觸發jump
            {
                velocity.y = jumpSpeed;
            }

            velocity.y -= grivaty * Time.deltaTime;
            Player.Move(velocity * Time.deltaTime);
        }

        //檢查是否位於地面
        private void CheackIsGround()
        {
            //偵測是否與地面接觸
            isGround = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);

            if (isGround && velocity.y < 0)
            {
                velocity.y = -3.0f;
            }
        }

        //播放腳步聲
        private void PlayWalkingSound()
        {
            if (horizontalMove != 0 || verticalMove != 0)
            {
                WalkingSound.mute = false;
            }
            else
            {
                WalkingSound.mute = true;
            }
        }

        #endregion

    }
}


