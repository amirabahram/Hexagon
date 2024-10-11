using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        anim.SetBool("Idle", true);
    }

    public void clickedOnDice()
    {
        anim.SetBool("Idle", false);
        rigid.AddForce(new Vector2(0f, 10f));
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "DiceHolder")
        {
            anim.SetBool("Idle", true);
        }
    }
}
