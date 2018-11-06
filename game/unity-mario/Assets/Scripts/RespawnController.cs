using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {

    public List<Respawner> respawnableObjects;

    // Use this for initialization
    void Awake() {
        respawnableObjects = new List<Respawner>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void respawn()
    {
        foreach(Respawner obj in respawnableObjects)
        {
            obj.gameObject.SetActive(true);
            obj.respawn();
        }
    }

    public void register(Respawner obj)
    {
        respawnableObjects.Add(obj);
    }
}
