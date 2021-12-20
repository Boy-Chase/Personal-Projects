using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // goes to testing level
    public void ToLevel()
    {
        SceneManager.LoadScene(1);
    }
}
