using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHitSomething = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void Update()
    {
        if (!isHitSomething)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isHitSomething = true;
        Stick();
        Destroy(gameObject, 5f);
    }

    void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
