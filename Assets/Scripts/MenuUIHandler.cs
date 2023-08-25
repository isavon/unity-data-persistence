using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;

    void Start()
    {
        if (ScoreManager.Instance.bestScoreName != "")
        {
            bestScoreText.gameObject.SetActive(true);
            bestScoreText.text = "Best Score : " + ScoreManager.Instance.bestScoreName + " : " + ScoreManager.Instance.bestScore;
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
