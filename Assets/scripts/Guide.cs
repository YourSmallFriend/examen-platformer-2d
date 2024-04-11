using UnityEngine;
using UnityEngine.SceneManagement;

public class Guide : MonoBehaviour
{
    // Method to handle the start button click event
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Guide");
    }
}
