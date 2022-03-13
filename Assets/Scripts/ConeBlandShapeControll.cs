using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConeBlandShapeControll : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer rend;


    private void Start()
    {
        Invoke("StartAnimation", 2);
    }
    public void StartAnimation()
    {
        StartCoroutine(BlandShapeAnimation());
    }

    IEnumerator BlandShapeAnimation()
    {
        float bland1 = 0;
        float bland2 = 0;
        float bland3 = 0;
        float bland4 = 0;
        float bland5 = 0;

        while (bland1 < 100)
        {
            bland1 += Time.deltaTime * 100;
            rend.SetBlendShapeWeight(0, bland1);
            yield return null;
        }

        while (bland1 >= 0)
        {
            bland1 -= Time.deltaTime * 100;
            rend.SetBlendShapeWeight(0, bland1);
            yield return null;
        }
    }

    
}
