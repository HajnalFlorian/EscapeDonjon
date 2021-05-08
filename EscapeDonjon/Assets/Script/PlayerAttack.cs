using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : playerMouvement
{
    public playerMouvement infoPlayer;

    public Transform attackPointUp;
    public Transform attackPointoiwn;
    public Transform attackPointLeft;
    public Transform attackPointRight;


    public GameObject AttackpointDown;
    public GameObject AttackpointUp;
    public GameObject AttackpointLeft;
    public GameObject AttackpointRight;



    // Update is called once per frame
    void Update()
    {
        if (infoPlayer.animator.GetFloat("yDirection") > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpriteUpPop());
        }
        if (infoPlayer.animator.GetFloat("xDirection") < 0 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpriteLeftPop());
        }
        if (infoPlayer.animator.GetFloat("yDirection") < 0 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpriteDownPop());
        }
        if (infoPlayer.animator.GetFloat("xDirection") > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpriteRightPop());

        }

    }

    IEnumerator SpriteDownPop()
    {
        AttackpointDown.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        AttackpointDown.SetActive(false);
    }
    IEnumerator SpriteUpPop()
    {
        AttackpointUp.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        AttackpointUp.SetActive(false);
    }
    IEnumerator SpriteLeftPop()
    {
        AttackpointLeft.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        AttackpointLeft.SetActive(false);
    }
    IEnumerator SpriteRightPop()
    {
        AttackpointRight.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        AttackpointRight.SetActive(false);
    }
}
