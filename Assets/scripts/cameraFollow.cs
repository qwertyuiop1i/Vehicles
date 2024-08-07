using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    public AudioSource As;
    public AudioClip c;
    private void Start()
    {
        As = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (target == null)

            target = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position,
 desiredPosition, ref velocity, smoothTime);

    }
    public void clickSound()
    {
        As.PlayOneShot(c);
    }
}
