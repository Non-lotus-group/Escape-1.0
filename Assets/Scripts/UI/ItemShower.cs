using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemShower : MonoBehaviour
{
    public PlayerCollections pc;
    public TMP_Text T1;
    public TMP_Text T2;
    public TMP_Text T3;
    public TMP_Text T4;
    public TMP_Text T5;
    public TMP_Text T6;
    
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollections>();
    }

    // Update is called once per frame
    void Update()
    {
        T1.text = pc.items[0].stacks.ToString();
        T2.text = pc.items[1].stacks.ToString();
        T3.text = pc.items[2].stacks.ToString();
        T4.text = pc.items[3].stacks.ToString();
        T5.text = pc.items[4].stacks.ToString();
        T6.text = pc.items[5].stacks.ToString();
    }
}
