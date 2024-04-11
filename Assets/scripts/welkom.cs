using UnityEngine;
using UnityEngine.SceneManagement;

public class welkom : MonoBehaviour
{
    // Method to handle the start button click event
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Startscherm");
    }
}
