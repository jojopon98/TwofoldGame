using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour {

    // Use this for initialization
    public float FireSpeed;
    Rigidbody2D FireBody;
    public GameObject DestroyedStump;
	void Start () {
        FireBody = GetComponent<Rigidbody2D>();
	}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            other.gameObject.SetActive(false);
            DestroyedStump.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update () {
        FireBody.velocity = Vector2.right * FireSpeed;
	}
}
