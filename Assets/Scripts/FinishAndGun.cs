using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class FinishAndGun : MonoBehaviour
{//-6 05 6.5
    [SerializeField] Animator animator;
    [SerializeField] Transform cameraTarget;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioSource GunAudio;

    [SerializeField] GameObject particle;
    [SerializeField] GameObject Firepoint;
    bool GunReady = false;
    LevelManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            manager = FindObjectOfType<LevelManager>();
            manager.PlayerInputActive = false;
            manager.FinishScore = manager.Score;
            StartCoroutine(FinishScene());
        }
    }

    IEnumerator FinishScene()
    {
        CameraFollow camera = FindObjectOfType<CameraFollow>();
        camera.smoothSpeed = 0.005f;
        camera.target = cameraTarget;
        camera.offset = new Vector3(-6f, 0.5f, 6.5f);
        audio.Play();
       // yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(4);
        camera.smoothSpeed = 0.01f;
        animator.SetTrigger("StartGun");
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(0.5f);
        camera.transform.rotation = Quaternion.Euler(0, 90, 0);
        camera.smoothSpeed = 0.3f;
        camera.target = Firepoint.transform;
        camera.offset = new Vector3(-12.34f, 3f, 0f);
        GunReady = true;

    }

    IEnumerator Fire()
    {
        GunReady = false;
        CameraFollow camera = FindObjectOfType<CameraFollow>();
        camera.smoothSpeed = 0.06f;
        animator.SetTrigger("FireGun");
        GunAudio.Play();
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        yield return new WaitForSeconds(0.2f);
        GameObject PlayerMainBone = GameObject.FindGameObjectWithTag("Player");
        camera.offset = new Vector3(-11.5f, 3f, 0f);
        Rigidbody body = FindObjectOfType<Player>().body;
        Instantiate(particle, Firepoint.transform.position, Firepoint.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        body.velocity = new Vector3(0, 0, 0);
        camera.offset = new Vector3(-15, 1f, 0f);
        PlayerMainBone.transform.position = Firepoint.transform.position + new Vector3(0,0,0);
        manager.StartCoroutine(manager.MenuLoadTimer());

        float velosity = FindObjectOfType<LevelManager>().Fat;
        if (velosity > 600)
        {
            velosity = 600;
        }
        if (velosity < 180)
        {
            velosity = 180;
        }
        body.velocity = Firepoint.transform.forward * (velosity);
        //body.AddForce(Firepoint.transform.forward * (10 + FindObjectOfType<LevelManager>().Fat));
        camera.target = body.transform;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GunReady)
        {
            StartCoroutine(Fire());
        }
    }

}
