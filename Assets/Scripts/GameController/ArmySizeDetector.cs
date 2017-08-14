using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmySizeDetector : MonoBehaviour {

    public static int armySizeCounter;
    public static int armySizeOrigin;
    public static int maxArmySize;
    public static int minArmySize;
    public static int dogmusArmySize;
    public int armyShow;
    public int maxArmyShow;
    public int minArmyShow;


	void Awake () {
        armySizeOrigin = 1;
        maxArmySize = 17;
        minArmySize = 8;
	}
	
	void Update () {
        armyShow = armySizeOrigin;
        maxArmyShow = maxArmySize;
        minArmyShow = minArmySize;

        CalculateArmySize();
	}

    private void CalculateArmySize()
    {
        if (StageDetector.IsStageClear == false)
        {
            armySizeOrigin = maxArmySize - ScoreCounter.fakeScore;
        }
    }
}
