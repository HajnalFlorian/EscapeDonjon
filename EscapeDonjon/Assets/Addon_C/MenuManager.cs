using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{


    public void LoadLevel()
    {
        //Charge la sc�ne � l'index de build 2, et d�charge celle � l'index 1.
        GameManager.Instance.LoadScene(2, 1, 1f);
    }

    public void Leave()
    {
        Application.Quit();
    }

}
