using UnityEngine;

namespace Misun
{

    public class Bullet : MonoBehaviour
    {

        public Rigidbody rb;

        private void Start()
        {
            BoxCollider bulletColl;
            bulletColl = GetComponent<BoxCollider>();

            
                rb= GetComponent<Rigidbody>();

        }

        private void OnCollisionEnter(Collision collision)
        {
          
            
            Freeze();
            Invoke(nameof(bulletDestroy), 1.0f);

        }

        private void Freeze()
        {
            rb.Sleep();
            Debug.Log("¤l¼u°±¤î");

        }
        private void bulletDestroy()
        {
            Destroy(this.gameObject);
        }







    }
}



