using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;
    Vector3 smoothedPosition;

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
	{
        
		Vector3 desiredPosition = target.position + offset;
	    smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float xOffset = originalPos.x + Random.Range(-0.3f, 0.3f) * magnitude;
            float yOffset = originalPos.y + Random.Range(-0.3f, 0.3f) * magnitude;
            transform.localPosition = Vector3.Lerp(transform.position, new Vector3(xOffset, yOffset, originalPos.z),smoothSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = smoothedPosition;
    }
}
