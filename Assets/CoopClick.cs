using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoopClick : MonoBehaviour
{
    [SerializeField] private AudioClip soundClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Image image;
    [SerializeField] private string endSceneName;
    [SerializeField] private float displayTime = 5f;

    void Start()
    {
        messageText.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (audioSource && soundClip)
        {
            audioSource.PlayOneShot(soundClip);
        }

        messageText.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
        Debug.Log("Image active: " + image.gameObject.activeSelf);

        StartCoroutine(ShowAndEnd());
    }


    private IEnumerator ShowAndEnd()
    {
        yield return new WaitForSeconds(displayTime);

        messageText.gameObject.SetActive(false);
        image.gameObject.SetActive(false);

        SceneManager.LoadScene(endSceneName);
    }
}