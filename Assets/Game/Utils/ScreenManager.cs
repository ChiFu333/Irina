using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static Vector2 GetMouseGlobalPos()
    {
        Vector3 p = Input.mousePosition;
        p.z = 20;
        return Camera.main.ScreenToWorldPoint(p);
    }
    public static float GetAngleBedween(Vector2 a, Vector2 b)
    {
        Vector2 arrow = a - b;
        return Mathf.Rad2Deg * Mathf.Atan2(arrow.normalized.y, arrow.normalized.x); 
    }
}
