using UnityEngine;
using TMPro;

public class ChickenCollide : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ouchText;
    [SerializeField] private AudioClip ouchClip;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        ouchText.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(ouchClip);
            ouchText.gameObject.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ouchText.gameObject.SetActive(false);
        }
    }
}