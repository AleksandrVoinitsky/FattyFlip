using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class FinishAndGun : MonoBehaviour
{
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
        camera.transform.rotation = Quaternion.Euler(10, 65, 0);
        camera.smoothSpeed = 0.8f;
        camera.offset = new Vector3(-11f, 5.5f, -5.5f);
        PlayerMainBone.transform.position = Firepoint.transform.position + new Vector3(0,0,0);
        //manager.StartCoroutine(manager.MenuLoadTimer());

        float velosity = FindObjectOfType<LevelManager>().Fat;
        velosity = velosity / 4;
        if (velosity > 500)
        {
            velosity = 500;
        }
        if (velosity < 1)
        {
            velosity = 1;
        }
        
        camera.target = body.transform;
        //velosity = 200;
        float startVelosity = velosity;
        while (velosity > startVelosity / 2)
        {
            body.velocity = Firepoint.transform.forward * 50;
            body.angularVelocity = new Vector3(10, 15, 20);
            velosity -= Time.fixedDeltaTime * 10;
            yield return null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GunReady)
        {
            StartCoroutine(Fire());
        }
    }

}
