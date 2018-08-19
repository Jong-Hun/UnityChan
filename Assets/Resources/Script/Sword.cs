using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	void Start () {
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        transform.Rotate(new Vector3(180.0f, 0, 0));
    }
	
	void Update () {
		
	}
}
