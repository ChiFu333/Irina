using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform point;
    public Transform forRotationPoint;
    private int ammo = 12;
    private float timeBetweenShoot = 0.2f;
    private float reload = 1.2f;

    private bool reloading = false;

    private Timer shootTimer, reloadTimer;
    private void Start()
    {
        shootTimer = new Timer();
        reloadTimer = new Timer();
    }
    void Update()
    {
        if(PushReload() && !reloading)
        {
            reloading = true;
            reloadTimer.SetTime(reload);
        }
        else if(reloading)
        {
            if(reloadTimer.Execute())
            {
                ammo = 12;
                MainCanvas.instance.reloadSlider.value = 0;
                reloading = false;
            }
            else
            {
                MainCanvas.instance.reloadSlider.value = reloadTimer.GetTimePassed() / reload;
            }
        }
        else if (shootTimer.Execute() && Input.GetMouseButton(0))
        {
            ShootBullet();
            ammo--;
            shootTimer.SetTime(timeBetweenShoot);
        }
    }
    private void ShootBullet()
    {
        GameObject b = Instantiate(bullet, point.position, Quaternion.identity);
        Bullet bul = b.GetComponent<Bullet>();
        bul.movement = new Vector2(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad),Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));
    }
    private bool PushReload()
    {
        return Input.GetMouseButton(0) && ammo == 0 || Input.GetKeyDown(KeyCode.R);
    }
}
