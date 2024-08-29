using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D body;
    public Vector2 movement;
    public float speed = 10;
    public float timeToDestroy = 2;
    public float damage = 1;
    private Timer timer;
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        timer = new Timer(timeToDestroy);
    }
    private void FixedUpdate()
    {
        body.velocity = movement * speed;
        if (timer.Execute()) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
}
