using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseItemController : MonoBehaviour
{
    public GameObject choosePanel;
    public int trueItemID;
    public bool isUsed = false;

    public GameObject boss;
    public GameObject character;

    public GameObject[] items;

    private Animator characterAnimator;
    private Animator bossAnimator;

    public string[] triggerNames;
    public float[] delays;

    private void Awake()
    {
        characterAnimator = character.GetComponent<Animator>();
        bossAnimator = boss.GetComponent<Animator>();
    }

    public void ChooseItem(int itemID) {
        if (!isUsed) {
            if (itemID == trueItemID)
            {
                StartCoroutine(TrueChoose(itemID));
            }
            else
            {
                StartCoroutine(FalseChoose(itemID));
            }
            isUsed = true;
            choosePanel.SetActive(false);
        }
        

    }

    public void ChooseItemHeroAnimatio(int itemID) {
        if (!isUsed)
        {
            if (itemID == trueItemID)
            {
                StartCoroutine(TrueChooseHeroAnimation(triggerNames[itemID], delays[itemID]));
            }
            else
            {
                StartCoroutine(FalseChooseHeroAnimation(triggerNames[itemID], delays[itemID]));
            }
            isUsed = true;
            choosePanel.SetActive(false);
        }
    }

    public IEnumerator TrueChoose(int _itemID) {

        characterAnimator.SetTrigger("UseItem");
        items[_itemID].SetActive(true);

        //yield return new WaitForSeconds(1f);

        bossAnimator.SetTrigger("TrueAnimation");
        yield return new WaitForSeconds(2f);

        yield break;

    }

    public IEnumerator FalseChoose(int _itemID)
    {

        characterAnimator.SetTrigger("UseItem");
        items[_itemID].SetActive(true);

        //  yield return new WaitForSeconds(1f);

        bossAnimator.SetTrigger("FalseAnimation");
        yield break;

    }


    public IEnumerator TrueChooseHeroAnimation(string triggerName, float _delay)
    {

        characterAnimator.SetTrigger(triggerName);

        yield return new WaitForSeconds(_delay);

        bossAnimator.SetTrigger("TrueAnimation");
        yield return new WaitForSeconds(2f);

        yield break;

    }

    public IEnumerator FalseChooseHeroAnimation(string triggerName, float _delay)
    {

        characterAnimator.SetTrigger(triggerName);

        yield return new WaitForSeconds(_delay);

        bossAnimator.SetTrigger("FalseAnimation");
        yield break;

    }




}
