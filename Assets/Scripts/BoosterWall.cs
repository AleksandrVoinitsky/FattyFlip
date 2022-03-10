using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BoosterWall : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] string WallText;
    [SerializeField] bool add;
    AudioSource source;

    private void Start()
    {
        textMesh.text = WallText;
        source = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "PlayerPart")
        {
            GetComponent<Animator>().SetBool("Destroy", true);
            source.Play();
            GetComponent<Collider>().isTrigger = true;
            FindObjectOfType<LevelManager>().WallBoosterEffect(add);
            Destroy(textMesh);
            Destroy(gameObject, 3);
        }
    }

}
