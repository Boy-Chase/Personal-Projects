using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // number of scene to load
    [SerializeField]
    public int sceneInt;

    // goes to testing level
    public void ToLevel()
    {
        PlayerPrefs.SetString("inventory", "");
        PlayerPrefs.SetInt("level", 4);
        SceneManager.LoadScene(sceneInt);
    }
}
