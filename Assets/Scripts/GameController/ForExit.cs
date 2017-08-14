using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForExit : MonoBehaviour {

    public Transform startingPoint;

    public GameObject PauseMenu;
    public GameObject CreditMenu;
    public GameObject player;
    public GameObject rotatePlayer;
    public Image DieMenu;

    public bool IsPaused;
    private Color c;
    [SerializeField] public bool OldukMu;

    private void Awake()
    {
        startingPoint = player.GetComponent<Transform>();
    }

    void Start () {
        IsPaused = false;
        c = DieMenu.color;
        c.a = 0;
        OldukMu = false;
    }
	
	void Update () {
        MenuOpener();
        InDeadLine();
	}

    void MenuOpener()
    {
        if (Input.GetKeyUp("escape"))
        {
            IsPaused = !IsPaused;

            if (IsPaused == true && CanSlider.IsDead == false)
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else if(IsPaused == false && CanSlider.IsDead == false)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }      
    }

    public void OyundanCikis()
    {
        Application.Quit();
    }

    public void HazirlayanlardanCikis()
    {
        CreditMenu.SetActive(false);
    }

    public void HazirlayanlardanOpen()
    {
        CreditMenu.SetActive(true);
    }

    public void TekrarOynaDown()
    {
        Time.timeScale = 1;
        IsPaused = false;
        Application.LoadLevel("main");
    }

    public void InDeadLine()
    {
        if (CanSlider.IsDead == true /*&& OldukMu == false*/)
        {
            if (c.a < 0.9f)
            {
                OldukMu = true;

                c.a += 0.5f * Time.deltaTime;
                rotatePlayer.transform.Rotate(Vector3.forward * Time.deltaTime * -50);
            }
            else if (c.a >= 0.9f && OldukMu == true && rotatePlayer.transform.eulerAngles.z>-80f)
            {
                OldukMu = false;
                PauseMenu.SetActive(true);
                IsPaused = true;
                Time.timeScale = 0;
            }
            DieMenu.color = c;
        }
    }
}
