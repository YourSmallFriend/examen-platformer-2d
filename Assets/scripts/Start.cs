using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    // Method to handle the start button click event
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
