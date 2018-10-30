using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizeSpell : MonoBehaviour {
    public GameObject Player;
    public bool canGrow;
    public float x = 2f;
    public float y = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Player.transform.position;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Sprout"))
        {
            canGrow = true;
            Debug.Log("Very hard.");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Sprout"))
        {
            canGrow = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canGrow && collision.gameObject.name.Equals("Sprout"))
        {
            if (x < 20 && y < 20)
            {
                collision.gameObject.transform.localScale = new Vector2(x++, y++);
            }
            else
            {
                canGrow = false;
            }
        }
    }
}
