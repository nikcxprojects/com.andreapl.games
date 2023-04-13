using UnityEngine;

public class Ball : MonoBehaviour
{
    private int health = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
