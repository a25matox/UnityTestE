using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneScript : MonoBehaviour
{
    public List<string> sceneList = new List<string>();
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneList[0]);
    }
}
