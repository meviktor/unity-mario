using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicDestroyMonitor : MonoBehaviour {
    public UIController uiController;
    private void OnTriggerEnter2D()
    {
        GameObject sonic = GameObject.FindGameObjectWithTag("Sonic");
        MoveSonicAfterDestroy(sonic);
        DestroyMonitor();
        uiController.addRing(10);
    }

    private void MoveSonicAfterDestroy(GameObject sonic)
    {
        Rigidbody2D sonicRigidBody = sonic.GetComponent<Rigidbody2D>();
        sonicRigidBody.velocity = new Vector2(sonicRigidBody.velocity.x, -sonicRigidBody.velocity.y);
    }

    private void DestroyMonitor()
    {
        //change the sprite of the monitor of the destroyed one
        GameObject ringMonitor = this.gameObject.transform.parent.gameObject;
        Sprite[] monitorSprites = Resources.LoadAll<Sprite>("Sprites/monitors");
        Sprite newSpriteToDisplay = monitorSprites[15];
        SpriteRenderer sr = ringMonitor.GetComponent<SpriteRenderer>();
        sr.sprite = newSpriteToDisplay;
        //play the destroy animation of the monitor
        ringMonitor.GetComponent<Animator>().Play("DestroyMonitor");
        ringMonitor.GetComponent<Animator>().SetBool("HittedBySonic", true);
        //disable the Edge Collider component of the monitor
        ringMonitor.GetComponent<BoxCollider2D>().enabled = false;
        //disable the Edge Collider which collosion "triggered" the destroy process - its the parameter of this function
        this.GetComponent<EdgeCollider2D>().enabled = false;
    }
}
