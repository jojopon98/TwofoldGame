using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalFalls : MonoBehaviour {

    public GameObject HangingCrystal;
    public GameObject FallenCrystal;
    public EarthquakeSpell Earthquake;
    public AlignmentView Chaotic;
    public Material ChaoticView;

	void Update () {
		if (Input.GetButton("Earthquake Spell"))
        {
            Earthquake.enabled = true;
            HangingCrystal.SetActive(false);
            FallenCrystal.SetActive(true);
        }
        if (Input.GetButtonUp("Earthquake Spell"))
        {
            Chaotic.material = ChaoticView;
            Chaotic.enabled = true;
        }
	}
}
