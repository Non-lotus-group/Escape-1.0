using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemsByInput : MonoBehaviour
{
    public PlayerCollections Pc;
    // Start is called before the first frame update
    void Start()
    {
        Pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollections>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Pc.items[0].stacks += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Pc.items[1].stacks += 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Pc.items[2].stacks += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Pc.items[3].stacks += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Pc.items[4].stacks += 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Pc.items[5].stacks += 1;
        }
    }
}
