using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextlevel : MonoBehaviour
{
    public bool canLoadLevel = true;
    public int numTargets = 0;

    private BoxCollider bc;
    public GameObject loadingText;
    public Slider loadingBar;
    public Text progressText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            loadNextLevel();
        }
    }
    public void loadNextLevel()
    {
        if (canLoadLevel && numTargets <= 0)
        {
            loadingText.SetActive(true);
            StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadAsynchronously(int levelIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelIndex);
        loadingText.SetActive(true);
        loadingBar.gameObject.SetActive(true);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            loadingBar.value = progress;
            progressText.text = progress * 100 + "%";
            yield return null;
        }
    }
}
