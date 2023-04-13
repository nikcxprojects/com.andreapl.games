using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _ballPrefab;

    private void Awake()
    {
        _ballPrefab = Resources.Load<Rigidbody2D>("ball");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ball = Instantiate(_ballPrefab, transform.parent);

            var mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = (mPos - transform.position).normalized;

            ball.transform.localPosition = transform.position;
            ball.AddForce(dir * 25, ForceMode2D.Impulse);
        }
    }
}
