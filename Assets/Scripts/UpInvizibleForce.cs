using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpInvizibleForce : MonoBehaviour
{
    [SerializeField] GameObject Particle;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "PlayerPart")
        {
            collision.rigidbody.AddForce(Vector3.down * 5000);
            Instantiate(Particle, collision.transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
