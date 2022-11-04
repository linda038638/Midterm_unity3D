using UnityEngine;

namespace Misun
{

    public class Movement : MonoBehaviour
    {
        private CharacterController cc;
        [SerializeField]
        private float moveSpeed, jumpSpeed;
        private float horizontalMove, verticalMove;
        private Vector3 vec;
        public float grivaty;
        private Vector3 velocity;

        [SerializeField]
        private Transform groundCheck;
        private float checkRadius =0.4f;
        public LayerMask whatIsGround;
        private bool isGround;



        private void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        private void Update()
        {
            CheackIsGround();
            movement();

        }

        private void movement()
        {
            horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
            verticalMove = Input.GetAxis("Vertical") * moveSpeed;

            vec = transform.forward * verticalMove + transform.right * horizontalMove;
            cc.Move(vec * Time.deltaTime);
            if (Input.GetButtonDown("Jump") && isGround)
            {
                velocity.y = jumpSpeed;
            }

            velocity.y -= grivaty * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
        }

        private void CheackIsGround()
        {
            isGround = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);

            if (isGround && velocity.y < 0)
            {
                velocity.y = -3.0f;
            }
        }

    }
}


