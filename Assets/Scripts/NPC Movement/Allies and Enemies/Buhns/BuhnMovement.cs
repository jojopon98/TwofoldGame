using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuhnMovement : MonoBehaviour {

    public bool Left;
    public float Speed;
    public float Jump;
    float time;
    public float JumpTime;
    float chance;
    public bool onGround;
    public GameObject exit;
    public Color green;
    public bool IsGreen;
    private float counter;
    public AlignmentView Chaotic;
    public Material ChaoticView;
    Rigidbody2D rb2D;
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        time = 0f;
        Left = true;
        IsGreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > JumpTime)
        {
            chance = Random.value * 100;
            if (chance < 50 && onGround)
            {
                BuhnJump();
                onGround = false;
            }
            else if (chance < 100)
            {
                ChangeDirection();
            }
            time = 0f;
        }
        counter = GameObject.FindGameObjectsWithTag("Buhn").Length;
        if (counter == 3f)
        {
            Speed = 1f;
            Jump = 5f;
            JumpTime = 1f;
        }
        if (counter == 2f)
        {
            Speed = 3f;
            Jump = 7f;
            JumpTime = 1f;
        }
        else if (counter == 1f)
        {
            Speed = 5f;
            Jump = 9f;
            JumpTime = 1f;
        }
    }
    void BuhnJump()
    {
        if (Left)
        {
            rb2D.velocity = Vector2.up * Jump + Vector2.left * Speed;
        }
        else
        {
            rb2D.velocity = Vector2.up * Jump + Vector2.right * Speed;
        }
    }
    void BuhnRun()
    {
        if (Left) // left = true, right = false
        {
            rb2D.velocity = Vector2.left * Speed;
        }
        else
        {
            rb2D.velocity = Vector2.right * Speed;
        }
    }
    void ChangeDirection()
    {
        if (Left)
        {
            Left = false;
            sr.flipX = true;
        }
        else
        {
            Left = true;
            sr.flipX = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetButton("Interact") && collision.gameObject.CompareTag("Buhn"))
        {
            sr.color = green;
            IsGreen = true;
            Speed = 0f;
            Jump = 0f;
            JumpTime = 1f;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Buhn"))
        {
            onGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire Spell"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Fire Spell") && counter == 1f)
        {
            gameObject.SetActive(false);
            exit.SetActive(true);
            Chaotic.material = ChaoticView;
            Chaotic.enabled = true;
        }
    }
}
