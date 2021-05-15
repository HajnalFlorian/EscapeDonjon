using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : playerMouvement
{
    public playerMouvement infoPlayer;

    public float attackRange = 0.5f;
    public float NextAttackPop = 0f;
    public float AttackRatePop = 2f;

    public LayerMask EnemiLayer;

    public int Damage = 3;

    public int Hp;
    public int HpMax = 20 ;

    public Transform attackPointUp;
    public Transform attackPointDown;
    public Transform attackPointLeft;
    public Transform attackPointRight;


    public GameObject AttackpointDown;
    public GameObject AttackpointUp;
    public GameObject AttackpointLeft;
    public GameObject AttackpointRight;


    private void Start()
    {
        Hp = HpMax;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= NextAttackPop)
        {
            if (infoPlayer.animator.GetFloat("yDirection") > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(SpriteUpPop());
                NextAttackPop = Time.time + 1f / AttackRatePop;

            }
            else if (infoPlayer.animator.GetFloat("xDirection") < 0 && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(SpriteLeftPop());
                NextAttackPop = Time.time + 1f / AttackRatePop;

            }
            else if (infoPlayer.animator.GetFloat("yDirection") < 0 && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(SpriteDownPop());
                NextAttackPop = Time.time + 1f / AttackRatePop;

            }
            else if (infoPlayer.animator.GetFloat("xDirection") > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(SpriteRightPop());
                NextAttackPop = Time.time + 1f / AttackRatePop;

            }
        }


    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Time.timeScale = 0;
    }

    void AttackUp()
    {
        //detection coup
        Collider2D[] hitEnemi =  Physics2D.OverlapCircleAll(attackPointUp.position, attackRange, EnemiLayer);

        //dommage 
        foreach (Collider2D enemy in hitEnemi)
        {
            enemy.GetComponent<SmallEnemi>().TakingDamage(Damage);
        }
    }
    
    void AttackDown()
    {
        //detection coup
        Collider2D[] hitEnemi = Physics2D.OverlapCircleAll(attackPointDown.position, attackRange, EnemiLayer);

        //dommage 
        foreach (Collider2D enemy in hitEnemi)
        {
            enemy.GetComponent<SmallEnemi>().TakingDamage(Damage);
        }
    }

    void AttackLeft()
    {
        //detection coup
        Collider2D[] hitEnemi = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, EnemiLayer);

        //dommage 
        foreach (Collider2D enemy in hitEnemi)
        {
            enemy.GetComponent<SmallEnemi>().TakingDamage(Damage);
        }
    }

    void AttackRight()
    {
        //detection coup
        Collider2D[] hitEnemi = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, EnemiLayer);

        //dommage 
        foreach (Collider2D enemy in hitEnemi)
        {
            enemy.GetComponent<SmallEnemi>().TakingDamage(Damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
        Gizmos.DrawWireSphere(attackPointUp.position, attackRange);
        Gizmos.DrawWireSphere(attackPointDown.position, attackRange);
    }

    IEnumerator SpriteDownPop()
    {
        AttackpointDown.SetActive(true);
        AttackDown();
        yield return new WaitForSeconds(0.25f);
        AttackpointDown.SetActive(false);
    }
    IEnumerator SpriteUpPop()
    {
        AttackpointUp.SetActive(true);
        AttackUp();
        yield return new WaitForSeconds(0.25f);
        AttackpointUp.SetActive(false);
    }
    IEnumerator SpriteLeftPop()
    {
        AttackpointLeft.SetActive(true);
        AttackLeft();
        yield return new WaitForSeconds(0.25f);
        AttackpointLeft.SetActive(false);
    }
    IEnumerator SpriteRightPop()
    {
        AttackpointRight.SetActive(true);
        AttackRight();
        yield return new WaitForSeconds(0.25f);
        AttackpointRight.SetActive(false);
    }
}
