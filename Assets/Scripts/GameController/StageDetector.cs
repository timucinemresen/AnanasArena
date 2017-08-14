using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageDetector : MonoBehaviour {
    public static int mevcutStage;
    public int stageNumber;
    public static bool IsStageClear;
    public Text stageText;

    private void Start()
    {
        stageNumber = 1;
        mevcutStage = 1;
        IsStageClear = false;
    }

    private void Update()
    {
        ShowMevcutStage();
        NextStage();
    }

    private void ShowMevcutStage()
    {
        stageNumber = mevcutStage;
        stageText.text = stageNumber.ToString();
    }

    private void NextStage()
    {
        if(IsStageClear==false && ArmySizeDetector.armySizeOrigin == 0)
        {
            IsStageClear = true;
        }
        else if(IsStageClear==true && ArmySizeDetector.armySizeOrigin == 0)
        {
            mevcutStage++;
            Debug.Log(stageNumber.ToString());
            Debug.Log("STAGECLEAR!");
            ScoreCounter.fakeScore = 0;
            MaxArmyDuzenleyici();
            ArmySizeDetector.armySizeCounter = ArmySizeDetector.minArmySize;
            IsStageClear = false;
        }
    }

    private void MaxArmyDuzenleyici()
    {
        ArmySizeDetector.maxArmySize = 17 + mevcutStage * 3;
    }
}
