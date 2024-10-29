using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 startPosition;

    void Start()
    {
        // starto position
        startPosition = transform.position;
    }

    void Update()
    {
        // movement
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // patikrina ar paliete siena
        if (collision.gameObject.CompareTag("Wall"))
        {
            // resetina zaidejo position
            transform.position = startPosition;
        }
    }
}