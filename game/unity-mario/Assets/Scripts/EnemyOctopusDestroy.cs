using UnityEngine;

public class EnemyOctopusDestroy : MonoBehaviour {
    private void OnTriggerEnter2D()
    {
        GameObject sonic = GameObject.FindGameObjectWithTag("Sonic");
        MoveSonicAfterDestroy(sonic);
        DestroyOctopus();
    }

    private void MoveSonicAfterDestroy(GameObject sonic)
    {
        Rigidbody2D sonicRigidBody = sonic.GetComponent<Rigidbody2D>();
        sonicRigidBody.velocity = new Vector2(sonicRigidBody.velocity.x, -sonicRigidBody.velocity.y);
    }

    private void DestroyOctopus()
    {
        GameObject octopus = this.gameObject.transform.parent.gameObject;
        //play the destroy animation of the octopus
        octopus.GetComponent<Animator>().Play("DestroyEnemy");
        //megszüntetjük a gameObjectet
        Object.Destroy(octopus, 0.35f);
    }
}
