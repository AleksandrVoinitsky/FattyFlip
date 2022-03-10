using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRomover : MonoBehaviour
{
    [SerializeField] float LifeTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    
}
