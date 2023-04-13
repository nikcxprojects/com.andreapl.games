using UnityEngine.UI;
using UnityEngine;

public class SoundOption : MonoBehaviour
{
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;

    private void Start()
    {
        var img = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioListener.pause = !AudioListener.pause;
            img.sprite = AudioListener.pause ? off : on;
        });
    }
}
