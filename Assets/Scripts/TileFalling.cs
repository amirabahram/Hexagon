using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileFalling : MonoBehaviour
{
    private bool playerEntered = false;
    private Rigidbody2D rigid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerEntered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FallTile();
            StartCoroutine(DeactiveAfterSeconds());
            //Destroy(gameObject, 2f);
            //var ke =  Grid.Instance._tiles.Where(k => k.Value == null).Select(k => k.Key).ToList();
            //foreach(var k in ke)
            //{
            //    Grid.Instance._tiles.Remove(k);
            //}
        }
    }
    void FallTile()
    {
        rigid =gameObject.GetComponent<Rigidbody2D>();
        rigid.isKinematic = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

    }
    IEnumerator DeactiveAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
