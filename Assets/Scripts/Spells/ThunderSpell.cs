using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpell : MonoBehaviour {

    // Use this for initialization
    public float ThunderSpeed;
    Rigidbody2D ThunderBody;
    public GameObject ElectricitySupply;

    void Start()
    {
        ThunderBody = GetComponent<Rigidbody2D>();
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Electricity Supply"))
        {
            other.gameObject.SetActive(false);
            if (other.gameObject.CompareTag("Laser Gun"))
            {
                other.gameObject.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("Buhn") || other.gameObject.CompareTag("Lunaak"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ThunderBody.velocity = Vector2.right * ThunderSpeed;
        ThunderBody.velocity = Vector2.up * ThunderSpeed;
        ThunderBody.velocity = Vector2.left * ThunderSpeed;
    }
}
