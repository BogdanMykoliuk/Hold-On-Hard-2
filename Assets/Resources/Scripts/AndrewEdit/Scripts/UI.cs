using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _tapToPlay;

    public void HideTextTapToPlay()
    {
        _tapToPlay.SetActive(false);
    }

    public void ShowTextTapToPlay()
    {
        _tapToPlay.SetActive(true);
    }
}
