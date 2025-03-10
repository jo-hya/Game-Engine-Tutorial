using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonClick : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
