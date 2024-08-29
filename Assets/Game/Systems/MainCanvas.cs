using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] public Slider reloadSlider;

    public static MainCanvas instance;

    public void Awake()
    {
        instance = this;
    }
}
