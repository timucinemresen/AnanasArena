using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanSlider : MonoBehaviour {

    public static float maxCanValue;
    public static float anlikCanValue;
    public Slider canSlider;

    public static bool IsDead;

	void Awake () {
        maxCanValue = 100;
        anlikCanValue = 100;
        canSlider.minValue = 0;
	}

    private void Start()
    {
        IsDead = false;
    }

    void Update () {
        CanDegeriKontrol();
        DeadGibiBiSey();

    }

    private void CanDegeriKontrol()
    {
        canSlider.value = anlikCanValue;
        canSlider.maxValue = maxCanValue;
    }

    private void DeadGibiBiSey()
    {
        if (anlikCanValue <= 0)
        {
            IsDead = true;
        }
        else
        {
            IsDead = false;
        }
            
    }
}
