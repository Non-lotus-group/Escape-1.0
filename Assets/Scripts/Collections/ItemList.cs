
using UnityEngine;

[System.Serializable]
public class ItemList
{
    public CollBase item;
    public string name;
    public int stacks;
    public ItemList(CollBase newItem, string newName, int newStacks)
    {
        item = newItem;
        name = newName;
        stacks = newStacks;
    }
}
