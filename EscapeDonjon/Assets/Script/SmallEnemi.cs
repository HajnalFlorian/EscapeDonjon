using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemi : MonoBehaviour
{
    public float hp;
    public float hpmax;


    // Start is called before the first frame update
    void Start()
    {
        hp = hpmax;
    }

    // Update is called once per frame
    public void TakingDamage(float damage)
    {
        hp -= damage;
        CheckDeath();
    }

    private void CheckOverHp()
    {
        if(hp > hpmax)
        {
            hp = hpmax;
        }
    }

    private void CheckDeath()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
