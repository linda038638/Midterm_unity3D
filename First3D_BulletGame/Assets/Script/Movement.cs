﻿using UnityEngine;

namespace Misun
{

    public class Movement : MonoBehaviour
    {
        private CharacterController cc;
        private AudioSource Bfx;
        [SerializeField]
        private float moveSpeed, jumpSpeed, rotateSpeed;
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
            cc = this.GetComponent<CharacterController>();
            Bfx = this.GetComponent<AudioSource>();
            Cursor.visible = false;

        }

        private void Update()
        {
            CheackIsGround();
            movement();
            Cursor.lockState = CursorLockMode.Confined;

        }

        private void movement()
        {
            horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
            verticalMove = Input.GetAxis("Vertical") * moveSpeed;

            if (horizontalMove != 0 || verticalMove != 0)
            {
                Bfx.mute = false;
            }
            else
            { Bfx.mute = true;
            }

            vec = transform.forward * verticalMove + transform.right * horizontalMove;
            cc.Move(vec * Time.deltaTime);

           // this.gameObject.transform.Rotate(0, Input.GetAxis("Horizontal")*rotateSpeed, 0);

            //跳躍
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


