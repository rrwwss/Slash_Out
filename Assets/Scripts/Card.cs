using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;

public class Card : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CardSO[] cardSOs;
    [SerializeField] private CardSO cardSO;
    [SerializeField] private Image rend;
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI cardDescText;
    [SerializeField] private TextMeshProUGUI cardCostText;

    private RectTransform _rect;

    private void Start()
    {
        _rect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        cardSO = cardSOs[Random.Range(0, cardSOs.Length)];
        SetCard();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ScoreManager.Instance.score - cardSO.CardCost >= 0)
        {
            ScoreManager.Instance.SetScore(-cardSO.CardCost);
            cardSO.CardMethodObject.GetComponent<ICardMethod>().DoCardMethod();
            SceneLoadManager.Instance.LoadGameScene();
            TurnManager.Instance.TurnValueUp();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ScaleCoroutine(1.2f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ScaleCoroutine(1));
    }

    private IEnumerator ScaleCoroutine(float value)
    {
        yield return _rect.DOScale(new Vector3(value, value), 1).SetEase(Ease.OutExpo).SetLink(gameObject).SetUpdate(true).WaitForCompletion();
    }

    [ContextMenu("SetCard")]
    private void SetCard()
    {
        cardNameText.text = cardSO.CardName;
        cardDescText.text = cardSO.CardDesc;
        cardCostText.text = $"Cost : {cardSO.CardCost}";
        rend.color = cardSO.CardColor;
    }
}
