using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject Player;
    void Update()
    {
        this.gameObject.transform.position = new Vector3(Player.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
