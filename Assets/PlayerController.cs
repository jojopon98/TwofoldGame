using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    public float Speed;
    public Rigidbody2D Rigidbody2D;
    public float Jump;
    public bool onGround;
	void Start () {
        onGround = true;
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal") * Speed;
        Vector2 Horizontal = new Vector2(moveHorizontal, Rigidbody2D.velocity.y);
        Rigidbody2D.velocity = Horizontal;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround == true)
            {
                Rigidbody2D.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                onGround = false;
            }
        }
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
