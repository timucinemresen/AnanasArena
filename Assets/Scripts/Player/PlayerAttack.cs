using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public bool IsAttackingTriggered;
    public bool IsPressingAttack;
    public Text scoreText;

    private void Start()
    {
        IsAttackingTriggered = false;
        IsPressingAttack = false;
    }

    public void OnCollisionStay(Collision other)
    {
        if (IsAttackingTriggered == true)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                ScoreCounter.scoreCounted++;
                ScoreCounter.fakeScore++;
                string ScoreString = ScoreCounter.scoreCounted.ToString();
                scoreText.text = ScoreString;
            }
            IsAttackingTriggered = false;
        }
    }

    public void AttackAction()
    {
        IsAttackingTriggered = true;
    }

    public void FinishAttackAction()
    {
        IsAttackingTriggered = false;
    }

}
