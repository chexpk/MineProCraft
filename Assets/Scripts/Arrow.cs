using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    bool isHitSomething = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void Update()
    {
        RotateByMoveDirection();
    }

    void RotateByMoveDirection()
    {
        if (isHitSomething) return;
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void OnCollisionEnter(Collision other)
    {
        Stick();
        TryDealDamage(other.gameObject);
        Destroy(gameObject, 5f);
    }

    private void TryDealDamage(GameObject enemy)
    {
        var damageable = enemy.GetComponent<IDamageable>();
        Debug.Log(damageable);
        if (damageable == null) return;
        damageable.TakeDamage(30);
    }

    void Stick()
    {
        isHitSomething = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
