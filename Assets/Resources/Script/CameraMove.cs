using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    Transform target;

	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + 1,
                                            transform.position.y,
                                            target.position.z - 3);
        transform.LookAt(target);
	}

}
