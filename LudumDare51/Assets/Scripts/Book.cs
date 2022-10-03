using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public int index = 0;
    [SerializeField] private PageFlip leftFlip;
    [SerializeField] private PageFlip rightFlip;
    public AudioSource flip;

    private void OnEnable()
    {
        leftFlip.OnPageFlip.AddListener(() => PageClicked(false));
        rightFlip.OnPageFlip.AddListener(() => PageClicked(true));
    }

    private void OnDisable()
    {
        leftFlip.OnPageFlip.RemoveAllListeners();
        rightFlip.OnPageFlip.RemoveAllListeners();
    }

    private void PageClicked(bool isRight)
    {
        int max = leftFlip.spriteList.Length;
        if (isRight && index < max - 1)
        {
            flip.Play();
            index++;
        } 
        if (!isRight && index > 0)
        {
            flip.Play();
            index--;
        }

        leftFlip.visual.sprite = leftFlip.spriteList[index];
        rightFlip.visual.sprite = rightFlip.spriteList[index];
    }
}
