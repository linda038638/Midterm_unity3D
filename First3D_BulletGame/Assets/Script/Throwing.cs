using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// 丟子彈 https://www.youtube.com/watch?v=F20Sr5FlUlE
/// </summary>
namespace Misun
{
    public class Throwing : MonoBehaviour
    {

        [Header("參考物")]
        public Transform cam;
        public Transform attackPoint;
        public GameObject objectToThrow;

        [Header("設定數量和冷卻時間")]
        public int totalThrows;
        public float throwcooldown;
        public TMP_Text bulletNumber;

        [Header("投擲")]
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

            //生成要丟的物件
            GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
            Debug.Log("生成!");
            
            //計數器-1
            totalThrows--;
            bulletNumber.text = "符咒：" + totalThrows;
            
            //得到剛體元件
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            if (objectToThrow) //如果子彈還存在 (避免生成碰撞消滅導致程式無法執行)
            {
                //方向
                Vector3 forceDirection = cam.transform.forward;
                RaycastHit hit;
                if (Physics.Raycast(cam.position, cam.forward, out hit, 500.0f))
                {
                    forceDirection = (hit.point - attackPoint.position).normalized;
                }


                //加力量
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





