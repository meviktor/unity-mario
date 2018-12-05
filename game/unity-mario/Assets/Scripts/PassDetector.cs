using UnityEngine;

public class PassDetector : MonoBehaviour {

    public GameObject whoWillPass;
    bool isNecessaryToListen = true;

    public static string STAR_POST_PASSED = "starpostpassed";
	
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
                if (PlayerPrefs.GetInt(STAR_POST_PASSED) == 1)
                {
                    Debug.Log("'Pass a star post' achieved earlier!");
                }
                else
                {
                    PlayerPrefs.SetInt(STAR_POST_PASSED, 1);
                    Debug.Log("'Pass a star post' now achieved!");
                }
            }
        }
	}
}
