using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using MoreMountains.NiceVibrations;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject particle;
    private LevelManager levelManager;
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "LevelPart")
        {
            levelManager.CameraShake(collision.relativeVelocity.magnitude);
            if(collision.relativeVelocity.magnitude > 1)
            {
                if(Random.Range(0,100) > 50)
                {
                    
                    Instantiate(particle, collision.transform.position, new Quaternion(0, 0, 0, 0));
                }
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                PlayAudio();
            }
        }
    }

    public void PlayAudio()
    {
        audio.volume = Random.Range(0.01f, 1);
        audio.pitch = Random.Range(0.8f, 1.3f);
        audio.Play();
    }
}
