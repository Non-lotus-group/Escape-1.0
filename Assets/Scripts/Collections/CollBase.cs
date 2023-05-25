using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class CollBase
{
    public abstract string GiveName();
    public virtual void Update(PlayerVariable player, int stacks) { }
    public virtual void OnHit(PlayerVariable player, int stacks) { }
    public virtual void OnKill(PlayerVariable player, int stacks, GameObject Iobject,float Damage) { }
    public virtual void OnLand(PlayerVariable player, int stacks, Vector3 PlayerNormal, GameObject Star, float Damage) { }
    public virtual void OnJump(PlayerVariable player, int stacks, bool AbleJump, int jumpCount, Vector3 jumpDir, ref int canJump) { }

}
public class HealingItem : CollBase
{
    public override string GiveName()
    {
        return "Healing Items";
    }
    public override void Update(PlayerVariable player, int stacks)
    {
        if (stacks != 0) { player.Health += stacks * 2; }

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
            float StarForce = Random.Range(5f, 7f);
            Vector3 StarDir = PlayerNormal*3f + (Random.Range(-3f, 3f) * player.transform.right);
            NewStar.GetComponent<StarBullet>().GetComponent<Rigidbody2D>().AddForce(StarForce * StarDir, ForceMode2D.Impulse);
            NewStar.GetComponent<StarBullet>().Rotation = Random.Range(50f, 280f);
            NewStar.GetComponent<PBattack>().Attack = Damage;
            NewStar.GetComponent<SpriteRenderer>().color = Random.Range(-1, 1) < 0 ? Color.red : Color.yellow;
            float ScaleOfStar = Random.Range(0.8f, 2f);
            NewStar.transform.localScale = new Vector3(ScaleOfStar, ScaleOfStar, ScaleOfStar);
            // NewStar's color will change or load colors on list or shader
        }
    }
}
public class JumpWhenFly : CollBase
{
    private bool hasAssignedCanJump = false;
    public override string GiveName()
    {
        return "Fly Jump";
    }
    public override void OnJump(PlayerVariable player, int stacks, bool AbleJump, int jumpCount, Vector3 jumpDir, ref int canJump)
    {
        if (!hasAssignedCanJump)
        {
            canJump = stacks;
            hasAssignedCanJump = true;
        }

        if (AbleJump == false && stacks > 0 && Input.GetKeyDown(KeyCode.Space) && canJump >= 0)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.GetComponent<Rigidbody2D>().AddForce(jumpDir * (jumpCount + 1), ForceMode2D.Impulse);
            canJump--;
            Debug.Log(canJump);
        }
        else if (AbleJump == true)
        {
            canJump = jumpCount;
            hasAssignedCanJump = false;
        }
    }
    //make sure thin function can only work jumpCount time before ableJump change to true

}
public class AttackScale : CollBase
{
    public override string GiveName()
    {
        return "Change Attack Scale";
    }
    public override void Update(PlayerVariable player, int stacks)
    {
        if (stacks != 0) { player.AttackScale = stacks * 2f; }

    }
}
public class SpawnMissile : CollBase
{
    float Poss;
    public override string GiveName()
    {
        return "Spawn Missile";
    }
    public override void OnKill(PlayerVariable player, int stacks, GameObject Iobject, float Damage)
    {
        Debug.Log("kill");
        Poss = Random.Range(0, 100) ;
        if (stacks != 0 && Poss <= 10*stacks)
        {
            for (int i = 0; i < stacks; i++)
            {
                Debug.Log("shoot");
                GameObject Missile = Object.Instantiate(Iobject, player.transform.position, Quaternion.identity);
                Missile.GetComponent<PBattack>().Attack = Damage;
            }
        }
    }
}
public class AttackHeal : CollBase
{
    public override string GiveName()
    {
        return "Heal When Attack";
    }
    public override void OnHit(PlayerVariable player, int stacks)
    {
        player.Health += 0.5f * stacks;
    }

}