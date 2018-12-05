using UnityEngine;

public class PickUpRing : MonoBehaviour {

    public UIController uiController;
    private bool ringPickedUp = false;
    SpriteRenderer sr;

    // Update is called once per frame
    void Update () {
        if(sr.bounds.Contains(new Vector2(this.transform.position.x, this.transform.position.y)))
        {
            this.GetComponent<Animator>().Play("RingPickedUp");
            if (!ringPickedUp)
            {
                uiController.addRing(1);
            }
            ringPickedUp = true;
            Object.Destroy(this.gameObject, 0.2f);
        }     
    }

    void Start()
    {
       sr = GameObject.FindGameObjectWithTag("Sonic").GetComponent<SpriteRenderer>();
    }
}
