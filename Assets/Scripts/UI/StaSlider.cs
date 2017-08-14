using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaSlider : MonoBehaviour {

    public static float maxStaValue;
    public static float anlikStaValue;
    public Slider staSlider;

    public static bool IsTired;

    void Awake()
    {
        maxStaValue = 100;
        anlikStaValue = 100;
        staSlider.minValue = 0;
    }

    private void Start()
    {
        IsTired = false;
    }

    void Update()
    {
        StaDegeriKontrol();
        TiredGibiBiSey();
    }

    private void StaDegeriKontrol()
    {
        staSlider.value = anlikStaValue;
        staSlider.maxValue = maxStaValue;
    }

    private void TiredGibiBiSey()
    {
        if (anlikStaValue == 0)
            IsTired = true;
    }
}
