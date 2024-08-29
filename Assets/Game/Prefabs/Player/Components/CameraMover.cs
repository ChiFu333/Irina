using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("SomeFloats")]
    [SerializeField] private float noMoveRadius;
    [Range(0f, 1f)] [SerializeField] private float cameraPower;
    void Update()
    {
        Vector2 arrow = ScreenManager.GetMouseGlobalPos() - (Vector2)Player.instance.transform.position;
        float distance = arrow.magnitude;
        if (distance > noMoveRadius)
        {
            
            Vector2 midpoint = Vector2.Lerp(Player.instance.transform.position, ScreenManager.GetMouseGlobalPos(), cameraPower);
            midpoint -= arrow.normalized * noMoveRadius * cameraPower;
            transform.position = new Vector3(midpoint.x,midpoint.y,-10);
        }
        else
        {
            transform.localPosition = new Vector3(0, 0, -10);
        }
    }
}
