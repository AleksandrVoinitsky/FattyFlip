using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private float distance = 2f;
    [SerializeField] GameObject sound;
    private Transform player;
    private bool moving;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        if (!moving)
        {
            
            if (Vector3.Distance(transform.position, player.position) <= distance)
            {
                moving = true;
            }
            
        }
        else
        {
            transform.DOScale(0, 0.25f);
            transform.position = Vector3.MoveTowards(transform.position, player.position, 15 * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.position) <= 0.2)
            {
                Instantiate(sound, transform.position, transform.rotation);
                FindObjectOfType<LevelManager>().AddScore(1);
                Destroy(gameObject);
            }
        }
    }
}
