using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemi : MonoBehaviour
{
    public float hp;
    public float hpmax = 3;

    public LayerMask layerPlayer;

    private Transform AttackPos;
    private float AttackRange = 0.60f;
    private int Damage = 1;
    private float AttackRate = 5f;
    private float NextAttack = 0f;


    // Start is called before the first frame update
    void Start()
    {
        hp = hpmax;
        AttackPos = transform.GetChild(0);
    }

    void Update()
    {
        if(Time.time >= NextAttack)
        {
            Attack();
            NextAttack = Time.time + 1f / AttackRate;
        }

    }

    // Update is called once per frame
    public void TakingDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void CheckOverHp()
    {
        if (hp > hpmax)
        {
            hp = hpmax;
        }
    }

    public void Die()
    {
        Debug.Log("Ennemi mort");
        Destroy(gameObject);
    }

    void Attack()
    {
        //detection coup
        Collider2D[] hitEnemi = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, layerPlayer);

        //dommage 
        foreach (Collider2D enemy in hitEnemi)
        {
            enemy.GetComponent<PlayerAttack>().TakeDamage(Damage);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);

    }
}
