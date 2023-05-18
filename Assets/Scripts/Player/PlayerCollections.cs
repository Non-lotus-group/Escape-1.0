using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollections : MonoBehaviour
{
    public List<ItemList> items = new List<ItemList>();

    public PlayerVariable Pv;
    public PlayerHealth Ph;
    public float Health;
    public GameObject StarBullet;
    // Start is called before the first frame update
    void Start()
    {
        Pv = GetComponent<PlayerVariable>();
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
        foreach (ItemList i in items)
        {
            i.item.OnLand(Pv, i.stacks, true, Pv.GrivityDir, StarBullet);
        }
    }

    IEnumerator CallItemUpdate() {
        foreach (ItemList i in items)
        {
            i.item.Update(Pv, i.stacks);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }
}
