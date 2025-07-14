using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] private Ease ease1;
    [SerializeField] private Ease ease2;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float waitTime;
    [SerializeField] private float waitTimee;
    [SerializeField] private Button button;
    [SerializeField] private RectTransform startButton;
    [SerializeField] private RectTransform configButton;
    [SerializeField] private RectTransform exitButton;


    private void Start()
    {
        SceneLoadManager.Instance.SetMainInt(0);
    }


    public void MainTitle()
    {
        switch (SceneLoadManager.Instance.MainInt)
        {
            case 0:
                transform.DOScale(1, 1).SetEase(ease1).From(0).SetLink(gameObject);
                SceneLoadManager.Instance.SetMainInt(1);
                break;
            case 1:
                transform.DOMove(new Vector2 (transform.position.x + xOffset, transform.position.y + yOffset), 1).SetLink(gameObject);
                SceneLoadManager.Instance.SetMainInt(3);
                ComeHereButtons();
                break;
        }
    }

    public void ComeHereButtons()
    {
        StartCoroutine(ComeHereCoroutine());
    }

    private IEnumerator ComeHereCoroutine()
    {
        startButton.DOAnchorPosX(0f, 0.5f).SetLink(gameObject);
        yield return new WaitForSeconds(0.2f);
        configButton.DOAnchorPosX(0f, 0.5f).SetLink(gameObject);
        yield return new WaitForSeconds(0.1f);
        exitButton.DOAnchorPosX(0f, 0.5f).SetLink(gameObject);
    }

}
