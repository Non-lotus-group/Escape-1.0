using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyHealth : MonoBehaviour
{
    public PlayerVariable Player;
    public float MaxHealth;
    public float Health;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerVariable>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Health <= 0)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerCollections>().CallFromOutside();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "PlayerBullet")
        {
            float Dam = collision.GetComponent<PBattack>().Attack;
            collision.GetComponent<PBattack>().CallWhenHit();
            Health -= Dam;

        }

    }
}
