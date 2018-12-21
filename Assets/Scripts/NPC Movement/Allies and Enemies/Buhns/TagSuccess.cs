using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSuccess : MonoBehaviour {
    public BuhnMovement BuhnA;
    public BuhnMovement BuhnB;
    public BuhnMovement BuhnC;
    public GameObject BuhnAGame;
    public GameObject BuhnBGame;
    public GameObject BuhnCGame;
    public GameObject exit;
    public AlignmentView Lawful;
    public Material LawfulView;

	// Use this for initialization
	void Start () {
        exit.SetActive(false);
        BuhnA = BuhnAGame.GetComponent<BuhnMovement>();
        BuhnB = BuhnBGame.GetComponent<BuhnMovement>();
        BuhnC = BuhnCGame.GetComponent<BuhnMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (BuhnA.IsGreen && BuhnB.IsGreen && BuhnC.IsGreen)
        {
            exit.SetActive(true);
            Lawful.material = LawfulView;
            Lawful.enabled = true;
        }
	}
}
