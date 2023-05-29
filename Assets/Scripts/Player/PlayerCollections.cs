using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollections : MonoBehaviour
{
    public List<ItemList> items = new List<ItemList>();

    public PlayerVariable Pv;
    public PlayerHealth Ph;
    public PlayerAttack Pa;
    public PlayerJump Pj;
    public float Health;
    public GameObject StarBullet;
    int JumpRef;
    public GameObject ValueOfHeal;
    // Start is called before the first frame update
    void Start()
    {
        Pv = GetComponent<PlayerVariable>();
        Pa = GetComponent<PlayerAttack>();
        Pj = GetComponent<PlayerJump>();
        Health = Pv.Health;
        HealingItem heal1 = new HealingItem();
        JumpStars StarB = new JumpStars();
        JumpWhenFly JumpF = new JumpWhenFly();
        AttackScale attackScale = new AttackScale();
        //AttackCoolDown attackCoolDown = new AttackCoolDown();
        SpawnMissile spawnMissile = new SpawnMissile();
        AttackHeal attackHeal = new AttackHeal();
        items.Add(new ItemList(heal1, heal1.GiveName(), 20));
        items.Add(new ItemList(StarB, StarB.GiveName(), 0));
        items.Add(new ItemList(JumpF, JumpF.GiveName(), 0));
        items.Add(new ItemList(attackScale, attackScale.GiveName(), 0));
        items.Add(new ItemList(spawnMissile, spawnMissile.GiveName(), 0));
        items.Add(new ItemList(attackHeal, attackHeal.GiveName(), 0));
        //items.Add(new ItemList(attackCoolDown, attackCoolDown.GiveName(), 0));
        StartCoroutine(CallItemUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ItemList i in items)
        {
            i.item.OnJump(Pv, i.stacks, Pv.AbleJump, Pv.JumpCount, Pj.JumpDir, ref JumpRef);
            i.item.Update(Pv, i.stacks);
        }
    }

    public void CallFromOutside()
    {
        foreach (ItemList i in items)
        {
            i.item.OnKill(Pv, i.stacks, Pv.Missile,Pa.attackValue*3);
        }
    }

    public void CallWhenEnemyHited()
    {
        foreach (ItemList i in items)
        {
            i.item.OnHeal(Pv, i.stacks, ValueOfHeal);
        }
    }

    IEnumerator CallItemUpdate()
    {
        foreach (ItemList i in items)
        {
            i.item.OnHeal(Pv, i.stacks, ValueOfHeal);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            foreach (ItemList i in items)
            {
                i.item.OnLand(Pv, i.stacks, Pv.GrivityDir, StarBullet, Pa.attackValue * 0.4f);
            }
        }
    }
}
