using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsManager : MonoBehaviour
{
    private const int MINROTATION = 1;
    private const int PLUSANGLE = 30;
    private const float MINDISTANCE = 3f;
    public GameObject leftHand, rightHand;
    public GameObject gun;

    public bool isInLeftHand = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float d = ((Vector2)Player.instance.transform.position - ScreenManager.GetMouseGlobalPos()).magnitude;
        if (d <= MINDISTANCE) 
        {
            ClampAngle(Player.instance.cursorAngle);
        }
        else
        {
            ClampAngle(ScreenManager.GetAngleBedween(ScreenManager.GetMouseGlobalPos(), gun.GetComponent<Gun>().forRotationPoint.position));
        }


        ChangeActiveHand(gun.transform.localRotation.eulerAngles.z);
    }
    private void ClampAngle(float angle)
    {
        if (angle % MINROTATION < MINROTATION / 2)
        {
            gun.transform.localRotation = Quaternion.Euler(0, 0, angle - (angle % MINROTATION));
        }
        else
        {
            gun.transform.localRotation = Quaternion.Euler(0, 0, angle - (angle % MINROTATION) + MINROTATION);
        }
    }
    private void ChangeActiveHand(float angle)
    {
        if (isInLeftHand && (angle >= 90 + PLUSANGLE && angle <= 270 - PLUSANGLE))
        {
            gun.transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(gun.transform.localScale.y) * -1);
            gun.transform.parent = rightHand.transform;
            gun.transform.localPosition = Vector3.zero;
            isInLeftHand = false;
        }
        else if (!isInLeftHand && (angle <= 90 - PLUSANGLE || angle >= 270 + PLUSANGLE))
        {
            gun.transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(gun.transform.localScale.y));
            gun.transform.parent = leftHand.transform;
            gun.transform.localPosition = Vector3.zero;
            isInLeftHand = true;
        }
    }
    public Transform GetActiveHand()
    {
        return gun.transform.parent;
    }
    
}
