using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer SR;
    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float angle = Player.instance.cursorAngle;
        if(angle <= 30 && angle >= -60) SR.sprite = sprites[0]; //�����
        else if (angle <= -60 && angle >= -120) SR.sprite = sprites[1]; //����
        else if (angle <= -120 || angle >= 150) SR.sprite = sprites[2]; //����
        else if (angle <= 150 && angle >= 120) SR.sprite = sprites[3]; //���������
        else if (angle <= 120 && angle >= 60) SR.sprite = sprites[4]; //�����
        else if (angle <= 60 && angle >= 30) SR.sprite = sprites[5]; //����������
    }
}
