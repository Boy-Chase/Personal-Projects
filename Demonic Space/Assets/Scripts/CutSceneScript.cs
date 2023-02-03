using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneScript : MonoBehaviour
{
    public AudioClip landSFX;
    private bool landed = false;
    private float landedTimer = 0.0f;

    public AudioClip winSFX;
    private bool win = false;
    private float winTimer = 0.0f;

    public GameObject winPanel;
    public GameObject shopPanel;

    public Text winText;

    int x = 0;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z < 41.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 25f * Time.deltaTime);
        }
        else if (x < 1000f)
        {
            gameObject.transform.Rotate(0, 15f * Time.deltaTime, 0);
            x++;
        }
        else if (11.8f < gameObject.transform.position.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 5f * Time.deltaTime, gameObject.transform.position.z);
        }
        else
        {
            if (!landed)
            {
                AudioSource.PlayClipAtPoint(landSFX, gameObject.transform.position);
                landed = true;
            }

            landedTimer += Time.deltaTime;

            if (2f < landedTimer)
            {
                if (!win)
                {
                    AudioSource.PlayClipAtPoint(winSFX, gameObject.transform.position);
                    win = true;
                }

                winTimer += Time.deltaTime;

                if (1f < winTimer)
                {
                    winText.text = "Mission Complete! Score: " + PlayerPrefs.GetInt("score");
                }

                // change over ui
                if (5f < winTimer)
                {
                    winPanel.SetActive(false);
                    shopPanel.SetActive(true);
                }
            }
        }
    }
}
