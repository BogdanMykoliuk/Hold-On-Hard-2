using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    private Animator transitionAnimator;
    private static int bossLevel;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("TransitionScreen") != null)
            transitionAnimator = GameObject.FindGameObjectWithTag("TransitionScreen").GetComponent<Animator>();
    }

    public void Reload(int number) {
        StartCoroutine(ReloadScene(number));
    }

    public IEnumerator ReloadScene(int number) {
        transitionAnimator.SetTrigger("EndGame");
        

        yield return new WaitForSeconds(0.34f);
        if (number % 2 == 0) {
            bossLevel = number;
            SceneManager.LoadScene("PreBoss");
        }
        else
            SceneManager.LoadScene("Level_" + number.ToString());
        yield break;
    }

    public void LoadBossScene() {
        SceneManager.LoadSceneAsync("Level_" + bossLevel.ToString());
        
    }
    
}
