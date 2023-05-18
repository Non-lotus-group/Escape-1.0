using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollections : MonoBehaviour
{
    public List<ItemList> items = new List<ItemList>();

    public PlayerVariable Pv;
    public PlayerHealth Ph;
    public PlayerAttack Pa;
    public float Health;
    public GameObject StarBullet;
    // Start is called before the first frame update
    void Start()
    {
        Pv = GetComponent<PlayerVariable>();
        Pa = GetComponent<PlayerAttack>();
        Health = Pv.Health;
        HealingItem heal1 = new HealingItem();
        JumpStars StarB = new JumpStars();
        items.Add(new ItemList(heal1, heal1.GiveName(), 0));
        items.Add(new ItemList(StarB, StarB.GiveName(), 2));
        StartCoroutine(CallItemUpdate());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator CallItemUpdate() {
        foreach (ItemList i in items)
        {
            i.item.Update(Pv, i.stacks);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall") {
            foreach (ItemList i in items)
            {
                i.item.OnLand(Pv, i.stacks,  Pv.GrivityDir, StarBullet, Pa.attackValue * 0.4f);
            }
        }
    }

    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Wall")
    //    {
    //        ContactPoint2D contactPoint = other.contacts[0];
    //        playerVariable.GrivityDir = contactPoint.normal;

    //        if (CapCollider.IsTouching(other.collider))
    //        {
    //            playerVariable.IsWalking = true;
    //            ThisRigbody.gravityScale = 0;

    //            playerVariable.AbleJump = true;
    //            playerVariable.IsJump = false;
    //        }
    //        else
    //        {
    //            ThisRigbody.AddForce(playerVariable.GrivityDir * (playerVariable.JumpCount + 1), ForceMode2D.Impulse);
    //            //will make player cannot move for few seconds
    //            // health -- 

    //        }
    //    }
    //}
}
