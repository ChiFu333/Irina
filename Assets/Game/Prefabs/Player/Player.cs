using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerController controller;
    [SerializeField] public HandsManager hands;

    public static Player instance;
    public float cursorAngle;
    public void Start()
    {
        instance = this;
    }
    private void Update()
    {
        CalculateAngle();
    }
    private void CalculateAngle()
    {
        Vector3 p = Input.mousePosition;
        p.z = 20;
        Vector2 arrow = Camera.main.ScreenToWorldPoint(p) - transform.position;
        cursorAngle = Mathf.Rad2Deg * Mathf.Atan2(arrow.normalized.y, arrow.normalized.x);
    }
}
