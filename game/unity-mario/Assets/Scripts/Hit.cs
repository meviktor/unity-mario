﻿using UnityEngine;

public class Hit : MonoBehaviour
{
    void Update()
    {
        SpriteRenderer sr = GameObject.FindGameObjectWithTag("Sonic").GetComponent<SpriteRenderer>();
        if (sr.bounds.Contains(new Vector2(this.transform.position.x, this.transform.position.y)))
        {
            UIController cont = GameObject.FindGameObjectWithTag("UIControlling").GetComponent<UIController>();
            cont.resetRing();
            GameObject.FindGameObjectWithTag("Sonic").GetComponent<Respawner>().respawn();
            this.gameObject.SetActive(false);
        }
    }
}