using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutGrows : MonoBehaviour
{

    public GameObject Sprout;
    public AlignmentView Lawful;
    public Material LawfulView;

    void Update()
    {
        if (Input.GetButtonUp("Fertilize Spell"))
        {
            Lawful.material = LawfulView;
            Lawful.enabled = true;
        }
    }
}