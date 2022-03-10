using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxAngSfx : MonoBehaviour
{
    [SerializeField] bool RandomPitch;
    [SerializeField] float DestroyTime = 5;

    void Start()
    {
        if (RandomPitch)
        {
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.3f);
        }
        
        Destroy(gameObject, DestroyTime);
    }


}
