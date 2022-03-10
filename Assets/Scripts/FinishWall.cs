using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class FinishWall : MonoBehaviour
{
    private bool Used = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "PlayerPart" )
        {
            if (!Used)
            {
                Used = true;
                MMVibrationManager.Haptic(HapticTypes.MediumImpact);
                GetComponent<Animator>().SetTrigger("Destroy");
            }
        }
    }
}
