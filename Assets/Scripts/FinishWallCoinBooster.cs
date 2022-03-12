using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishWallCoinBooster : MonoBehaviour
{
    [SerializeField] int Boost;
    [SerializeField] GameObject Text;
    [SerializeField] private GameObject confetti;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(Text);
            Instantiate(confetti, other.transform.position, Quaternion.identity);
            LevelManager manager = FindObjectOfType<LevelManager>();
            source.Play();
            manager.AddScore(manager.FinishScore * Boost);
            manager.ResetTime();
        }
    }
}
