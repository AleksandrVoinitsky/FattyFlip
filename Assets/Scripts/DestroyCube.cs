using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyCube : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" || collision.transform.tag == "PlayerPart")
        {
            GetComponent<Animator>().SetBool("Destroy", true);
            source.Play();
            GetComponent<Collider>().isTrigger = true;
            Destroy(gameObject, 3);
        }
    }

    
}
