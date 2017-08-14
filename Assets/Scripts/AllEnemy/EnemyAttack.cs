using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public EnemyMove moveScript;
    public Animator animator;
    public GameObject player;
    public Rigidbody rb;

    public float backforce;
    public bool enterTrig;
    public float meeleeCan;

    float timeLeft;
    bool girdiMi;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Start () {
        moveScript = GetComponent<EnemyMove>();
        animator = GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody>();

        enterTrig = false;
        meeleeCan = 10;
        girdiMi = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enterTrig = true;
            animator.SetTrigger("IsEnemyAttack");
            timeLeft = 0.7f;
            girdiMi = true;
            //rb.AddForce(transform.forward * -100 * backforce);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            moveScript.moveSpeed = 0.25f;
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0 && girdiMi==true )
            {
                if (SwordAnimator.RealBlock == false)
                {
                    CanSlider.anlikCanValue -= meeleeCan;
                }
                girdiMi = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            moveScript.moveSpeed = moveScript.fakeMoveSpeed;
            enterTrig = false;
        }
    }
}
