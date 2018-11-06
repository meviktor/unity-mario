using UnityEngine;

public class PickUpRing : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        SpriteRenderer sr = GameObject.FindGameObjectWithTag("Sonic").GetComponent<SpriteRenderer>();
        if(sr.bounds.Contains(new Vector2(this.transform.position.x, this.transform.position.y)))
        {
            this.GetComponent<Animator>().Play("RingPickedUp");
            Object.Destroy(this.gameObject, 0.2f);
        }     
    }
}
