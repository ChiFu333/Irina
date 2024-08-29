using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody2D body;
    private Vector2 movement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement = movement.normalized;
    }
    private void FixedUpdate()
    {
        Vector2 delta = movement * Speed * Time.deltaTime;
        Vector2 newPosition = body.position + delta;
        body.MovePosition(newPosition);
    }
}
