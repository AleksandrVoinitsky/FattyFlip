using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{
    [SerializeField] GameObject[] bonus;
    [SerializeField] GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        int bonusplace = 0;
        if (Random.Range(0, 100) > 20)
        {
            bonusplace = Random.Range(2, 10);
            Instantiate(bonus[Random.Range(0,bonus.Length)], new Vector3(transform.position.x, transform.position.y + bonusplace, 0), new Quaternion(0, 0, 0, 0));
        }
        
        for (int i = 1; i < 10; i++)
        {
            if (i == bonusplace) continue;
            if(Random.Range(0,100) > Random.Range(50,90))
            {
                Instantiate(coin, new Vector3(transform.position.x, transform.position.y +  i, 0), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    
}
