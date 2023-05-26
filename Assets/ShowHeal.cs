using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowHeal : MonoBehaviour
{
    public TMP_Text Heal;
    public float healValue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DesSelf());
    }

    // Update is called once per frame
    void Update()
    {
        Heal.text = "+" + healValue;

    }
    IEnumerator DesSelf() {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        transform.Translate(0, 0.1f, 0);
    }
}
