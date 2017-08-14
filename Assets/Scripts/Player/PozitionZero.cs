using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PozitionZero : MonoBehaviour {

    public Transform startingPoint;
    private float zeroX;
    private float zeroY;
    private float zeroZ;

    void Start () {
        startingPoint = gameObject.GetComponent<Transform>();
        zeroX = startingPoint.position.x;
        zeroY = startingPoint.position.y;
        zeroZ = startingPoint.position.z;
	}
	
	void Update () {
        ZeroPoint();
	}

    void ZeroPoint()
    {
        if (StageDetector.IsStageClear == true && ArmySizeDetector.armySizeOrigin == 0)
        {
            transform.position = new Vector3(zeroX, zeroY, zeroZ);
        }
    }
}
