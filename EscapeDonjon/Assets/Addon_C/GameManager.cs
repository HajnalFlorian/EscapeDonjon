using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool autoload_menu;

    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        //Si l'auto load est actif, charge le menu
        if (autoload_menu)
            LoadScene(1, -1);//Si le 2nd paramètre est à -1, il n'y a pas de scène à décharger
    }

    


    //================== Paramètres de chargement de scènes ===================//
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();


    public void LoadScene(int sceneToLoad_id, int sceneToUnload_id, float tempo = 0)
    {
        StartCoroutine(ILoadScene(sceneToLoad_id, sceneToUnload_id, tempo));
    }

    IEnumerator ILoadScene(int sceneToLoad_id, int sceneToUnload_id, float tempo)
    {
        yield return new WaitForSeconds(tempo);

        if (sceneToUnload_id != -1)
            scenesLoading.Add(SceneManager.UnloadSceneAsync(sceneToUnload_id));

        scenesLoading.Add(SceneManager.LoadSceneAsync(sceneToLoad_id, LoadSceneMode.Additive));

        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad_id));
        
    }

}
