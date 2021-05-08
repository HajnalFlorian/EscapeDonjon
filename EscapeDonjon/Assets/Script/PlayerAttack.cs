using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public GameObject AttackpointDown;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            AttackpointDown.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Q))
        {

        }
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
            AttackpointDown.SetActive(true);
        }
        else
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }

    }
}
