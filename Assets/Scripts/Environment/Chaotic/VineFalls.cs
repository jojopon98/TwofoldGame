using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineFalls : MonoBehaviour
{

    public GameObject Vines;
    public EarthquakeSpell Earthquake;
    public AlignmentView Chaotic;
    public Material ChaoticView;

    void Update()
    {
        if (Input.GetButton("Earthquake Spell"))
        {
            Earthquake.enabled = true;
            Vines.SetActive(true);
        }
        if (Input.GetButtonUp("Earthquake Spell"))
        {
            Chaotic.material = ChaoticView;
            Chaotic.enabled = true;
        }
    }
}