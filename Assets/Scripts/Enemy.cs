using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] atkTrm;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private float minTime;
    [SerializeField] private float minTime2;
    [SerializeField] private float maxTime;
    [SerializeField] private float maxTime2;
    [SerializeField] private float patternTime1;
    [SerializeField] private float patternTime21;
    [SerializeField] private float patternTime2;
    [SerializeField] private float patternTime22;
    [SerializeField] private float StartDelayTime;
    [SerializeField] private float StartDelayTime2;
    [SerializeField] private float endDelayTime;
    [SerializeField] private float endDelayTime2;

    [SerializeField] UnityEvent OnEnemyAtkStart;
    [SerializeField] UnityEvent OnEnemyAtkEnd;

    private float _patternTime;
    
    private void Start()
    {
        rend.sprite = sprites[0];
        StartCoroutine(EnemyCoroutine());
    }

    private IEnumerator EnemyCoroutine()
    {
        while (true)
        {
            if (TurnManager.Instance.Turn < 5)
            {
                _patternTime = Random.Range(minTime, maxTime);
                yield return new WaitForSeconds(_patternTime);
                Vector2 origin = transform.position;
                rend.sprite = sprites[1];
                transform.DOMove(atkTrm[Random.Range(0, atkTrm.Length)].position, patternTime1).SetLink(gameObject);
                yield return new WaitForSeconds(StartDelayTime);
                transform.DOMove(origin, patternTime2).SetLink(gameObject);
                rend.sprite = sprites[2];
                OnEnemyAtkStart?.Invoke();
                yield return new WaitForSeconds(endDelayTime);
                OnEnemyAtkEnd?.Invoke();
                rend.sprite = sprites[0];
            }
            else
            {
                _patternTime = Random.Range(minTime2, maxTime2);
                yield return new WaitForSeconds(_patternTime);
                Vector2 origin = transform.position;
                rend.sprite = sprites[1];
                transform.DOMove(atkTrm[Random.Range(0, atkTrm.Length)].position, patternTime21).SetLink(gameObject);
                yield return new WaitForSeconds(StartDelayTime2);
                transform.DOMove(origin, patternTime22).SetLink(gameObject);
                rend.sprite = sprites[2];
                OnEnemyAtkStart?.Invoke();
                yield return new WaitForSeconds(endDelayTime2);
                OnEnemyAtkEnd?.Invoke();
                rend.sprite = sprites[0];
            }
        }
    }

    public IEnumerator IHurtCoroutine()
    {
        rend.color = Color.white;
        if (Time.timeScale != 0)
            StartCoroutine(HurtWhiteCoroutine());
        GameManager.Instance.DoImpulse();
        yield return new WaitForSeconds(0.1f);
        rend.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        rend.color = Color.red;
    }

    private IEnumerator HurtWhiteCoroutine()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
    }

    public void IHurt()
    {
        StartCoroutine(IHurtCoroutine());
    }
}
