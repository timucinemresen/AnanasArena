using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMove : MonoBehaviour {

    public Transform player;

    public float desiredDistance;
    public float turnSpeed;
    public float moveSpeed;

    public bool IsWalking;
    public float fakeMoveSpeed;
    
    void Start () {
        player = GameObject.FindWithTag("Player").transform;
        IsWalking = false;
        fakeMoveSpeed = moveSpeed;
    }

    private void FixedUpdate()
    {
        Enemy1Move();
    }

    void Update () {
        Enemy1Turn();
	}

    //Enemy1 adlı düşmanın önüne doğru hareketi (AI)
    void Enemy1Move()
    {
        if (Vector3.Distance(player.position, this.transform.position) < desiredDistance)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            IsWalking = true;
            //Animatördeki Idle booleanını kontrol ediyor. Yürüme animasyonunu çalıştırır
        }
        else
        {
            IsWalking = false;
            //Animatördeki Idle booleanını kontrol ediyor. Yürüme animasyonunu durdurur
        }
    }
    
    //Enemy1 adlı düşmanın playera dönmesi (AI)
    void Enemy1Turn()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction), turnSpeed);
    }
}
