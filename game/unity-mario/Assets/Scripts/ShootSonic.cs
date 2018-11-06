using System.Collections.Generic;
using UnityEngine;

public class ShootSonic : MonoBehaviour
{
    public GameObject bulletProto;
    public float bulletSpeed;
    public float searchRadius;
    public float shootTimePeriod;

    public int bulletPoolSize;
    public List<Rigidbody2D> bulletPool;

    private float time;
    private float shootoffsetX = 0.4f;

	// Use this for initialization
	void Start ()
    {
        if (transform.lossyScale.x < 0)
        {
            bulletSpeed *= -1;
            shootoffsetX *= -1;
        }
        bulletPool = new List<Rigidbody2D>();

        for (int i = 0; i < bulletPoolSize; i++)
        {
            Rigidbody2D bulletClone =
                (Rigidbody2D)Instantiate(bulletProto.GetComponent<Rigidbody2D>());
            bulletClone.gameObject.SetActive(false);

            bulletPool.Add(bulletClone);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = this.GetComponent<Transform>().position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, searchRadius);
        foreach(Collider2D collider in colliders)
        {
            if(collider.gameObject.tag == "Sonic")
            {
                if ((transform.lossyScale.x > 0 && collider.gameObject.GetComponent<Transform>().position.x > this.GetComponent<EdgeCollider2D>().bounds.max.x) //az enemy colliderének leginkább jobbra lévő pontja?
                    || (transform.lossyScale.x < 0 && collider.gameObject.GetComponent<Transform>().position.x < this.GetComponent<EdgeCollider2D>().bounds.min.x))
                {
                    time += Time.deltaTime;
                    if(time >= shootTimePeriod)
                    {
                        FireBullet(collider.gameObject);
                        time = 0f;
                    }
                }
            }
        }

	}

    private void FireBullet(GameObject target)
    {
        this.GetComponent<Animator>().Play("enemy_type_one_attack");
        GameObject shootPoint = GameObject.Find("enemy_one_shootpoint");
        Rigidbody2D bulletClone = getBulletFromPool();
        bulletClone.transform.position = new Vector3(transform.position.x + shootoffsetX, transform.position.y, transform.position.z);
        bulletClone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        bulletClone.gameObject.SetActive(true);
        bulletClone.velocity = new Vector2(bulletSpeed, 0);
    }

    private Rigidbody2D getBulletFromPool()
    {
        foreach (Rigidbody2D bullet in bulletPool)
        {
            if (!bullet.gameObject.activeSelf)
            {
                return bullet;
            }
        }
        return null;
    }
}
