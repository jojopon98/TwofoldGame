using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaakMovement : MonoBehaviour
{

    private float Speed;
    private float Jump;
    float time;
    private float JumpTime;
    float chance;
    public bool onGround;
    private float counter;
    Rigidbody2D rb2D;
    SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        time = 0f;
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
                LunaakJump();
                onGround = false;
            }
            time = 0f;
        }
        counter = 3f;
        if (counter == 3f)
        {
            Speed = 5f;
            Jump = 9f;
            JumpTime = .25f;
            counter--;
        }
        else if (counter == 2f)
        {
            Speed = 3f;
            Jump = 7f;
            JumpTime = 1f;
            counter--;
        }
        else if (counter == 1f)
        {
            Speed = 5f;
            Jump = 9f;
            JumpTime = 1f;
            counter--;
        }
    }
    void LunaakJump()
    {
        rb2D.velocity = Vector2.up * Jump + Vector2.right * Speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Lunaak"))
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
        }
    }
    private void OnCollisionEnter2D(Collider2D collision)
    {

    }
}