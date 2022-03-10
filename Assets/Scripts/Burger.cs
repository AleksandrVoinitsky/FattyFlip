using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Burger : MonoBehaviour
{
    [SerializeField] private float distance = 2f;
    [SerializeField] int bonus;
    [SerializeField] GameObject sound;
    [SerializeField] GameObject particle;
    private Transform player;
    private bool moving;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
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
                Instantiate(particle, transform.position, new Quaternion(0, 0, 0, 0));
                Instantiate(sound, transform.position, transform.rotation);
                FindObjectOfType<LevelManager>().AddHealth(bonus);
                Destroy(gameObject);
            }
        }
    }
}
