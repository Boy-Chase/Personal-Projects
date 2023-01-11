using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneScript : MonoBehaviour
{
    public AudioClip landSFX;
    private bool landed = false;
    private float landedTimer = 0.0f;

    public AudioClip winSFX;
    private bool won = false;
    private float wonTimer = 0.0f;

    int x = 0;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z < 41.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 20f * Time.deltaTime);
        }
        else if (x < 1000)
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
            AudioSource.PlayClipAtPoint(rollSFX, gameObject.transform.position);
        }
    }
}
