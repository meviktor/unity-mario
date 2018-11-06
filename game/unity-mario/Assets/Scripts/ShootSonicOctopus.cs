using System.Collections.Generic;
using UnityEngine;

public class ShootSonicOctopus : MonoBehaviour
{
    public GameObject bulletProto;
    public float bulletSpeed;
    public float searchRadius;
    public float shootTimePeriod;

    public int bulletPoolSize = 3;
    public List<Rigidbody2D> bulletPool;

    private float time;
    private float shootoffsetX = 0.5f;
    private float shootoffsetY = 0.1f;

    // Use this for initialization
    void Start()
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
    void Update()
    {
        Vector3 pos = this.GetComponent<Transform>().position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, searchRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Sonic")
            {
                if ((transform.lossyScale.x > 0 && collider.gameObject.GetComponent<Transform>().position.x < this.GetComponent<EdgeCollider2D>().bounds.min.x) //az enemy colliderének leginkább balra lévő pontja?
                    || (transform.lossyScale.x < 0 && collider.gameObject.GetComponent<Transform>().position.x > this.GetComponent<EdgeCollider2D>().bounds.max.x))
                {
                    time += Time.deltaTime;
                    if (time >= shootTimePeriod)
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
        this.GetComponent<Animator>().Play("OctopusShootAnimation");
        Rigidbody2D bulletClone = getBulletFromPool();
        bulletClone.transform.position = new Vector3(transform.position.x - shootoffsetX, transform.position.y + shootoffsetY, transform.position.z);
        bulletClone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        bulletClone.gameObject.SetActive(true);
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * bulletSpeed, 0);
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