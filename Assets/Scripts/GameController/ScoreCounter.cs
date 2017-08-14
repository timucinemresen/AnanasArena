using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

    public static int scoreCounted;
    public static int fakeScore;

	void Start () {
        scoreCounted = 0;
        fakeScore = 0;
	}
}
