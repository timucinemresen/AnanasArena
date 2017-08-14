using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimator : MonoBehaviour {

    public Animator anim;
    public GameObject player;
    public static bool RealBlock;

    public float staDown;
    public float staUp;
    private float hor;
    private float ver;
    private int attack = Animator.StringToHash("Attack");

    private float attackSpeed;
    public float animatorAttackSpeedParameter;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsBlocking", false);
        RealBlock = false;
        //Bu kodu ilerleyen zamanda değiştirebilirim.
        staDown = 10;
        staUp = 20;
        animatorAttackSpeedParameter = 2.0f;
    }
	
	// Update is called once per frame
	void Update () {
        GetMoveAxis();
        WalkAnimation();
        AttackAnimation();
        //Block animasyonu da içinde
        StaminaDown();
    }

    // Yürümek için a,d,s,w basılıyor mu kontrolü için axisler
    void GetMoveAxis()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
    }

    // Yürüme ve koşma animasyon geçişleri
    void WalkAnimation()
    {
        if (hor == 0 && ver == 0)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }
    }


    // Tek seferlik atak animasyonu
    void AttackAnimation()
    {
        if (Input.GetButtonDown("Fire1"))
            anim.SetTrigger(attack);
    }

    // Sol click basılı durduğu sürece animasyonu pause yap
    public void PressedAttackButton()
    {
        if (Input.GetButton("Fire1"))
        {
            if (StaSlider.anlikStaValue > 10)
            {
                attackSpeed = 0;
            }
        }
        anim.SetFloat("AttackSpeed", attackSpeed);
    }

    // Belli süre silahı havada tutmak için gerisayım STAMİNA ÖNCESİ
    void StaminaDown()
    {
        if (Input.GetButton("Fire1"))
        {
            if (StaSlider.anlikStaValue > 5)
            {
                //StaSlider.anlikStaValue -= staDown * Time.deltaTime;
                if (Input.GetButton("Sprint"))
                {
                    StaSlider.anlikStaValue -= staDown * Time.deltaTime * 2;
                }
                else
                {
                    StaSlider.anlikStaValue -= staDown * Time.deltaTime;
                }
            }
            else
            {
                attackSpeed = animatorAttackSpeedParameter;
                anim.SetFloat("AttackSpeed", attackSpeed);
            }
        }
        else
        {
            attackSpeed = animatorAttackSpeedParameter;
            anim.SetFloat("AttackSpeed", attackSpeed);

            if (Input.GetMouseButton(1))
            {
                if (StaSlider.anlikStaValue > 5)
                {
                    anim.SetBool("IsBlocking", true);
                    //StaSlider.anlikStaValue -= staDown * Time.deltaTime;
                    if (Input.GetButton("Sprint"))
                    {
                        StaSlider.anlikStaValue -= staDown * Time.deltaTime * 3;
                    }
                    else
                    {
                        StaSlider.anlikStaValue -= staDown * Time.deltaTime*2;
                    }
                    RealBlock = true;
                }
                else
                {
                    anim.SetBool("IsBlocking", false);
                    RealBlock = false;
                }
            }
            else
            {
                anim.SetBool("IsBlocking", false);
                RealBlock = false;

                if (StaSlider.anlikStaValue < StaSlider.maxStaValue)
                {
                   // StaSlider.anlikStaValue += staUp * Time.deltaTime;
                    if (Input.GetButton("Sprint"))
                    {
                        StaSlider.anlikStaValue -= staDown * Time.deltaTime;
                    }
                    else
                    {
                        StaSlider.anlikStaValue += staUp * Time.deltaTime;
                    }
                }
                else
                {
                    if (Input.GetButton("Sprint"))
                    {
                        StaSlider.anlikStaValue -= staDown * Time.deltaTime;
                    }
                }
            }

        }
    }

}
