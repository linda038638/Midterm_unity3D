using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// ��l�u https://www.youtube.com/watch?v=F20Sr5FlUlE
/// </summary>
namespace Misun
{
    public class Throwing : MonoBehaviour
    {

        [Header("�ѦҪ�")]
        public Transform cam;
        public Transform attackPoint;
        public GameObject objectToThrow;

        [Header("�]�w�ƶq�M�N�o�ɶ�")]
        public int totalThrows;
        public float throwcooldown;
        public TMP_Text bulletNumber;

        [Header("���Y")]
        public float throwForce;
        public float throwUpwardForce;

        bool readToThrow = true;




        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && readToThrow && totalThrows>0)
            {
                Throw();
                
            }

        }



        private void Throw()
        {
            readToThrow = false;

            //�ͦ��n�᪺����
            GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
            Debug.Log("�ͦ�!");
            
            //�p�ƾ�-1
            totalThrows--;
            bulletNumber.text = "�ũG�G" + totalThrows;
            
            //�o����餸��
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            if (objectToThrow) //�p�G�l�u�٦s�b (�קK�ͦ��I�������ɭP�{���L�k����)
            {
                //��V
                Vector3 forceDirection = cam.transform.forward;
                RaycastHit hit;
                if (Physics.Raycast(cam.position, cam.forward, out hit, 500.0f))
                {
                    forceDirection = (hit.point - attackPoint.position).normalized;
                }


                //�[�O�q
                Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
                projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

                
                Invoke(nameof(ResetThrow), throwcooldown);
            }
           }

        private void ResetThrow()
        {
            readToThrow = true;
        }








    }
}





