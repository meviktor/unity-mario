using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

    public Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;

        GameObject.FindGameObjectWithTag("GameManager").
            GetComponent<RespawnController>().register(this);
	}

	public void respawn()
    {
        this.transform.position = startPosition;
    }
}
