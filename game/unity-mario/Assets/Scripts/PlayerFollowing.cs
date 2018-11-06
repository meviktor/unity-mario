using UnityEngine;
using System.Collections;

public class PlayerFollowing : MonoBehaviour
{
    public GameObject player;  
    private Vector3 offset;
    private float maxY;
    private float minY;

    void Start()
    {
        offset = transform.position - player.transform.position;
        maxY = transform.position.y;
        minY = GameObject.FindGameObjectWithTag("Deathpoint").transform.position.y;
    }

    void LateUpdate()
    {
        Vector3 newPos = player.transform.position + offset;
        if (newPos.y > maxY)
        {
            newPos.y = maxY;
        }
        if (newPos.y < minY)
        {
            newPos.y = minY;
        }
        transform.position = newPos;
    }
}