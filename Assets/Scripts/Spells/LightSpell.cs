using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpell : MonoBehaviour
{
    public GameObject Player;
    public bool starlight;
    public GameObject LightPlatform;
    public GameObject Star;
    public AlignmentView Lawful;
    public Material LawfulView;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            starlight = true;
            Star = other.gameObject;
            Star.GetComponent<SpriteRenderer>().enabled = false;
            Star.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            starlight = false;
            Star.GetComponent<SpriteRenderer>().enabled = true;
            Lawful.material = LawfulView;
            Lawful.enabled = true;
        }
    }
}

