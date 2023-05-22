using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public PlayerVariable Player;
    public float MaxHealth;
    public float Health;
    public List<ItemList> items = new List<ItemList>();
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerVariable>();
        AttackScale attackScale = new AttackScale();
        SpawnMissile spawnMissile = new SpawnMissile();
        AttackHeal attackHeal = new AttackHeal();
        items.Add(new ItemList(attackScale, attackScale.GiveName(), 0));
        items.Add(new ItemList(spawnMissile, spawnMissile.GiveName(), 0));
        items.Add(new ItemList(attackHeal, attackHeal.GiveName(), 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            foreach (ItemList i in items)
            {
                i.item.OnKill(Player,i.stacks,Player.Missile,this);
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health -= collision.GetComponent<PBattack>().Attack;
        foreach (ItemList i in items)
        {
            i.item.OnHit(Player, this, i.stacks);
        }
        Debug.Log(Health);
    }
}
