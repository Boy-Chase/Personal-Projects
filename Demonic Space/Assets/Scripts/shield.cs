using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.SceneManagement;

public class shield : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        // find our player
        Player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "bullet" && !other.gameObject.GetComponent<Bullet>().playerMade) || other.tag == "follower" || other.tag == "static" || other.tag == "boss" || other.tag == "asteroid" || other.tag == "ring")
        {
            Destroy(other.gameObject);

            Player.GetComponent<Player>().shieldOut = false;

            if (4 < Player.GetComponent<Player>().ss)
            {
                Player.GetComponent<Player>().sTimer = Player.GetComponent<Player>().ss;
            }
            else
            {
                Player.GetComponent<Player>().sTimer = 4;
            }

            Destroy(gameObject);
        }

    }
}
