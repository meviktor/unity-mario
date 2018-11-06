using UnityEngine;

public class EnemyTypeOneMove : MonoBehaviour {

    public float movingSpeed;
    public bool startMovingDown;
    public float changeDirectionTimeInSeconds;

    private bool isMovingDown;
    private float time;

    // Use this for initialization
    void Start () {
        isMovingDown = startMovingDown;
	}
	
	// Update is called once per frame
	void Update () {
        if (isMovingDown)
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - movingSpeed);
        }
        else //moving up
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + movingSpeed);
        }
        this.time += Time.deltaTime;
        if(this.time >= changeDirectionTimeInSeconds)
        {
            isMovingDown = !isMovingDown;
            time = 0f;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag == "Sonic")
       {
            this.GetComponent<Animator>().Play("DestroyEnemy");
            Object.Destroy(this.gameObject, 0.35f);
       }
    }
}
