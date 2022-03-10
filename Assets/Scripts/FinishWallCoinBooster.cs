using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishWallCoinBooster : MonoBehaviour
{
    [SerializeField] int Boost;
    [SerializeField] GameObject Text;
    [SerializeField] private GameObject confetti;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(Text);
            Instantiate(confetti, other.transform.position, Quaternion.identity);
            LevelManager manager = FindObjectOfType<LevelManager>();

            manager.AddScore(manager.FinishScore * Boost);
            manager.ResetTime();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
