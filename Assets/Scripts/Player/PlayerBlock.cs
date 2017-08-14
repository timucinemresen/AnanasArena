using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour {

    public bool IsBlocking;

	void Update () {
        IsBlockingFunction();
	}

    private void IsBlockingFunction()
    {
        if (Input.GetMouseButton(1))
        {
            IsBlocking = true; 
        }
        else
        {
            IsBlocking = false;
        }

    }
}
