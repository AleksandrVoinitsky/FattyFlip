using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] public Rigidbody body;
    [SerializeField] float Xspeed;
    [SerializeField] float JumpVelosity;
    [SerializeField] SkinnedMeshRenderer mesh;
    [SerializeField] AudioSource audio;
    private LevelManager manager;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        manager.SetDistance(body.position.x);
        if (manager.PlayerInputActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                body.velocity = new Vector3(body.velocity.x, JumpVelosity, body.velocity.z);
                body.velocity = new Vector3(Xspeed, body.velocity.y, body.velocity.z);
                PlayAudio();

            }
           
        }
    }

    public void SetBlandShape(int num)
    {
        if(num <= 200)
        {
            mesh.SetBlendShapeWeight(0, num);
        }
        body.gameObject.transform.DOScale(1.5f, 0.10f).OnComplete(() => { body.gameObject.transform.DOScale(1f, 0.10f); }); 
    }

    public void PlayAudio()
    {
        audio.volume = Random.Range(0.5f, 1);
        audio.pitch = Random.Range(0.8f, 1.3f);
        audio.Play();
    }
}
