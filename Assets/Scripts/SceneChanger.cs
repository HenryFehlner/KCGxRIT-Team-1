using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene()
    {
        Debug.Log("Changing Scene to " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
