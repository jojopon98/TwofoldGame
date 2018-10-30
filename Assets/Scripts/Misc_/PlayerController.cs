using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    public float Speed;
    public Rigidbody2D Rigidbody2D;
    public float Jump;
    public bool onGround;
    public bool onWall;
    public GameObject FireSpell;
    public GameObject FertilizeSpell;
	void Start () {
        onGround = true;
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal") * Speed;
        Vector2 Horizontal = new Vector2(moveHorizontal, Rigidbody2D.velocity.y);
        Rigidbody2D.velocity = Horizontal;
        if (Input.GetButtonDown("Jump"))
        {
            if (onGround == true)
            {
                Rigidbody2D.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                onGround = false;
            }
        }
        if (Input.GetButtonDown("Fire Spell"))
        {
            Vector2 position = new Vector2(transform.position.x + .5f, transform.position.y);
            Instantiate(FireSpell, position, FireSpell.transform.rotation);
        }
        if (Input.GetButton("Fertilize Spell"))
        {
            FertilizeSpell.SetActive(true);
        }
        if (Input.GetButtonUp("Fertilize Spell"))
        {
            FertilizeSpell.SetActive(false);
        }
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Tree"))
        {
            onWall = true;
            Speed = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (onWall == true)
        {
            onWall = false;
            Speed = 12f;
        }
    }
}
