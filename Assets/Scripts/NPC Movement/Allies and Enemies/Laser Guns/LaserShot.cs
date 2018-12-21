using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

    bool isShooting;
    public GameObject Laser;
    private float timer;
    public GameObject ElectricitySupply;

	// Use this for initialization
	void Start () {
        isShooting = true;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1 && isShooting == true)
        {
            if (Laser)
            {
                Instantiate(Laser, transform.position, Laser.transform.rotation);
            }
            timer = 0;
        }
        if (ElectricitySupply == false)
        {
            isShooting = false;
        }
	}
}
