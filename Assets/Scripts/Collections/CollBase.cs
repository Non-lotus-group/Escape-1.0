using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class CollBase          
{
    public abstract string GiveName();
    public virtual void Update(PlayerVariable player, int stacks) { }
    public virtual void OnHit(PlayerVariable player, EnemyBase enemy, int stacks) { }
    public virtual void Missile(PlayerVariable player, int stacks) { }
    public virtual void OnKill() { }
    public virtual void OnLand(PlayerVariable player, int stacks, Vector3 PlayerNormal, GameObject Star, float Damage) { }
}
public class HealingItem : CollBase
{
    public override string GiveName()
    {
        return "Healing Items";
    }
    public override void Update(PlayerVariable player, int stacks)
    {
        player.Health += stacks * 2;
    }
}
public class JumpStars : CollBase
{
    public override string GiveName()
    {
        return "Shoot Sparks";
    }
    public override void OnLand(PlayerVariable player, int stacks, Vector3 PlayerNormal, GameObject Star, float Damage)
    {
        int SpawnNum = Random.Range(stacks, stacks + 3);
        for (int i = 0; i < SpawnNum; i++)
        {
            GameObject NewStar = GameObject.Instantiate(Star, player.transform.position, Quaternion.identity);
            float StarForce = Random.Range(2f, 7f);
            Vector3 StarDir = PlayerNormal + (Random.Range(-3f, 3f) * player.transform.right);
            NewStar.GetComponent<StarBullet>().GetComponent<Rigidbody2D>().AddForce(StarForce * StarDir, ForceMode2D.Impulse);
            NewStar.GetComponent<StarBullet>().Rotation = Random.Range(50f, 280f);
            NewStar.GetComponent<StarBullet>().Damage = Damage;
            NewStar.GetComponent<SpriteRenderer>().color = Random.Range(-1, 1) < 0 ? Color.red : Color.yellow;
            float ScaleOfStar = Random.Range(0.8f, 2f);
            NewStar.transform.localScale = new Vector3(ScaleOfStar, ScaleOfStar, ScaleOfStar);
            // NewStar's color will change or load colors on list or shader
        }
    }
}
