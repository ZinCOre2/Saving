
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class LevelButton
{
    [SerializeField] private Button button;
    public Button Button => button;
    [SerializeField] private string sceneName;
    public string SceneName => sceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
