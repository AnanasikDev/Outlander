using UnityEngine;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour
{
    public static bool IsPlaying = true;
    private void Start()
    {
        IsPlaying = true;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
