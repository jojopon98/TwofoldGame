using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpell : MonoBehaviour
{
    public GameObject Player;
    public bool starlight;
    public GameObject LightPlatform;
    public float x = 2f;
    public float y = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            starlight = true;
            LightPlatform.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            starlight = false;
            LightPlatform.SetActive(false);
        }
    }
}

