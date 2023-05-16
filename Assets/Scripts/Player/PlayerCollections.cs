using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollections : MonoBehaviour
{
    public List<ItemList> items = new List<ItemList>();

    public PlayerVariable Pv;
    public PlayerHealth Ph;
    public float Health;
    // Start is called before the first frame update
    void Start()
    {
        Pv = GetComponent<PlayerVariable>();
        Health = Pv.Health;
        HealingItem heal1 = new HealingItem();
        items.Add(new ItemList(heal1, heal1.GiveName(), 0));
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
}
