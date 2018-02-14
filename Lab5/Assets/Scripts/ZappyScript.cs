using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZappyScript : MonoBehaviour {

    public int offset;

    private int count;

    private bool isActive;

    public GameObject zappyPart;

	// Use this for initialization
	void Start () {
        isActive = false;
        count = offset;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        count++;

        if(count >= 100 && !isActive)
        {
            isActive = true;
            zappyPart.gameObject.SetActive(true);
            count = 0;
        }


        if(count >= 150 && isActive)
        {
            isActive = false;
            zappyPart.gameObject.SetActive(false);
            count = 0;
        }
        
	}
}
