using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);

            if (name == "Player1")
            {
                FindObjectOfType<GameplayController>().UpdatePlayerScore(1);
                return;
            }

            FindObjectOfType<GameplayController>().UpdatePlayerScore(2);
        }
    }
}
