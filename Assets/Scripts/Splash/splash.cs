using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splash : MonoBehaviour {

    public Image tulpar;
    public Color c;

    private string levelName;
    AsyncOperation async;

	void Start () {
        c = tulpar.color;
        c.a = 0;
        levelName = "main";
        StartCoroutine("load");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update () {
        Darness();
	}

    void Darness()
    {
        if (c.a < 1.5f)
        {
            c.a += 0.5f * Time.deltaTime;
            tulpar.color = c;
        }
        else
        {
            ActivateScene();
        }
    }

    IEnumerator load()
    {
        async = Application.LoadLevelAsync(levelName);
        async.allowSceneActivation = false;
        yield return async;
    }

    public void ActivateScene()
    {
        async.allowSceneActivation = true;
    }
}
