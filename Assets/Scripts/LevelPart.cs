using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPart : MonoBehaviour
{
    [SerializeField] bool Sleep;

    // Start is called before the first frame update
    void Start()
    {
        if (Sleep)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Sleep)
        {
            if (collision.transform.tag == "Player" || collision.transform.tag == "PlayerPart")
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
