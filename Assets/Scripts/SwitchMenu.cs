using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("TestScene_Ezra");
    }
}
