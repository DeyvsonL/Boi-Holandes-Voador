using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMoviment : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb2;

    [SerializeField]
    private float speed = 40f;

    private int direction = 1;

    private void Start()
    {
        direction = gameObject.transform.position.x < 0 ? 1 : -1;
        rb2.velocity = new Vector2(speed * direction, 0);
        gameObject.GetComponent<SpriteRenderer>().flipX = gameObject.transform.position.x < 0 ? true : false;
    }
}
