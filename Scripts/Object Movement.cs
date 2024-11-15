using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float startingSpeed;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = startingSpeed;
    }

    void Update()
    {
        speed = GameSpeed.Instance.gameSpeed;
        rb.velocity = Vector2.left * startingSpeed* speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
