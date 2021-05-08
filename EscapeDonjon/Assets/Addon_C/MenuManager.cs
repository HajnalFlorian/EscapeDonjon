using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{


    public void LoadLevel()
    {
        //Charge la scène à l'index de build 2, et décharge celle à l'index 1.
        GameManager.Instance.LoadScene(2, 1, 1f);
    }

    public void Leave()
    {
        Application.Quit();
    }

}
