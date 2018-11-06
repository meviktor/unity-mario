using UnityEngine;

public class PassDetector : MonoBehaviour {

    public GameObject whoWillPass;
    bool isNecessaryToListen = true;
	
	// Update is called once per frame
	void Update () {
        if (isNecessaryToListen)
        {
            Transform chekpoint_upperbound = this.transform.Find("checkpoint_up");
            Transform checkpoint_lowerbound = this.transform.Find("checkpoint_down");
            if ((whoWillPass.transform.position.x < this.transform.position.x + 0.1 && whoWillPass.transform.position.x > this.transform.position.x - 0.1) &&
                whoWillPass.transform.position.y <= chekpoint_upperbound.transform.position.y &&
                whoWillPass.transform.position.y >= checkpoint_lowerbound.transform.position.y)
            {
                whoWillPass.GetComponent<Respawner>().startPosition = transform.position;
                this.GetComponentInChildren<Animator>().Play("StarPostHit");
                isNecessaryToListen = false;
            }
        }
	}
}
