using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    //speed for ball
    public float speed = 7.0f;
	// Use this for initialization
	void Start () {

        rigidbody2D.velocity = Vector2.one.normalized * speed;
	}

    float hitFactor (Vector2 ballPos, Vector2 playerPos, float playerHeight)
    {

        return (ballPos.y - playerPos.y) / playerHeight;
    }

    void OnCollisionEnter2D (Collision2D col)
    {

        if(col.gameObject.name == "Player1")
        {
            float y = hitFactor(transform.position, col.transform.position, ((BoxCollider2D)col.collider).size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            rigidbody2D.velocity = dir * speed;
        }

        if (col.gameObject.name == "Player2")
        {
            float y = hitFactor(transform.position, col.transform.position, ((BoxCollider2D)col.collider).size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            rigidbody2D.velocity = dir * speed;
        }

    }
}
