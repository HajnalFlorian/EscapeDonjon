using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMouvement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    public Animator animator;
    public float attackRate = 2f;
    public float NextAttack = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        TakeInput();
        Move();

    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        //
        if(direction.x != 0 || direction.y != 0)
        {
            SetAnimationMouvement(direction);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }

        // attack
        if (Time.time >= NextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attack");
                NextAttack = Time.time + 1f / attackRate;
            }
        }


    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.Z))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            direction += Vector2.left;

        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    private void SetAnimationMouvement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDirection", direction.x);
        animator.SetFloat("yDirection", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);



    }

    void Attact()
    {

    }

}

