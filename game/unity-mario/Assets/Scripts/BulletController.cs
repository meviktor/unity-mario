using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float timeToLive = 5.0f;

    private float spendTimeAsActive = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        spendTimeAsActive += Time.deltaTime;

        if (spendTimeAsActive >= timeToLive)
        {
            spendTimeAsActive = 0f;
            this.gameObject.SetActive(false);
        }
    }
}

