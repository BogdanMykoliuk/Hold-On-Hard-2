using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _tapToPlay;

    private void Start()
    {
        if (GameState.launchGame)
        {
            HideTextTapToPlay();
        }
    }

    public void HideTextTapToPlay()
    {
        _tapToPlay.SetActive(false);
        GameState.launchGame = true;
    }

    public void ShowTextTapToPlay()
    {
        _tapToPlay.SetActive(true);
    }
}
