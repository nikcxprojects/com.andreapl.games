using System;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private int count = 0;
    private TextMeshPro MyScoreText { get; set; }
    private Animation Animation { get; set; }
    [SerializeField] bool IsObstacle;

    public static Action OnBlockCollided { get; set; }

    private void Awake()
    {
        Animation = GetComponent<Animation>();
        MyScoreText = GetComponentInChildren<TextMeshPro>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.rigidbody == null)
        {
            return;
        }

        if (!IsObstacle)
        {
            OnBlockCollided?.Invoke();
            MyScoreText.text = $"{++count}";
            if(Animation.isPlaying)
            {
                Animation.Stop();
            }

            Instantiate(Resources.Load<GameObject>("sfx"), transform.parent);
            Animation.Play();
        }

        collision.rigidbody.AddForce(collision.transform.up * 10, ForceMode2D.Impulse);
    }
}
