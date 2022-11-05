using UnityEngine;

namespace Misun
{

    public class Bullet : MonoBehaviour
    {


        private void Start()
        {
            BoxCollider bullet;
            bullet = GetComponent<BoxCollider>();

        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(this.gameObject);
        }














    }
}



