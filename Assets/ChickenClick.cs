using System.Collections;
using UnityEngine;
using TMPro;


public class ChickenClick : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;

    void Start()
    {
        questText.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        Debug.Log("Chicken was clicked!");
        questText.gameObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay(2f));
    }

    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        questText.gameObject.SetActive(false);
    }
}
