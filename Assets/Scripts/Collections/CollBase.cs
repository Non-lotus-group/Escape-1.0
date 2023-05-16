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
    public virtual void OnLand(PlayerVariable player, int stacks) { }
}
public class HealingItem : CollBase {
    public override string GiveName()
    {
        return "Healing Items";
    }
    public override void Update(PlayerVariable player, int stacks)
    {
        player.Health += stacks * 2;
    }
}
