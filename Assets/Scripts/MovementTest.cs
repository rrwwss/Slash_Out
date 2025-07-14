using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovementTest : MonoBehaviour
{
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    [SerializeField] Sprite sprite3;
    [SerializeField] InputAction atkInput;
    [SerializeField] InputAction moveInput;
    [SerializeField] float yOffset;
    [SerializeField] float xOffset;
    [SerializeField] float xTime;
    [SerializeField] float yTime;
    [SerializeField] float delayTime;
    [SerializeField] bool canMove = true;

    [SerializeField] private UnityEvent OnPunchStart;
    [SerializeField] private UnityEvent OnPunchEnd;
    [SerializeField] private UnityEvent OnMoveStart;
    [SerializeField] private UnityEvent OnMoveEnd;

    private SpriteRenderer _rend;

    private void Awake()
    {
        _rend = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        atkInput.Enable();
        moveInput.Enable();
    }

    private void OnDisable()
    {
        atkInput.Disable();
        moveInput.Disable();
    }

    private void Update()
    {
        float mvInput = moveInput.ReadValue<float>();
        if (atkInput.IsPressed() && canMove)
        {
            StartCoroutine(PunchCoroutine());
        }

        if (mvInput < 0 && canMove)
        {
            StartCoroutine(MoveCoroutine(-1));
        }

        if (mvInput > 0 && canMove)
        {
            StartCoroutine(MoveCoroutine(1));
        }
    }

    private IEnumerator PunchCoroutine()
    {
        _rend.sprite = sprite2;
        canMove = false;
        OnPunchStart?.Invoke();
        transform.DOMoveY(transform.position.y + yOffset, yTime).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Unset).SetLink(gameObject);
        yield return new WaitForSeconds(yTime * 2);
        _rend.sprite = sprite1;
        OnPunchEnd?.Invoke();
        yield return new WaitForSeconds(delayTime);
        canMove = true;
    }

    private IEnumerator MoveCoroutine(int leftOrRight)
    {
        _rend.flipX = leftOrRight == -1 ? false : true;
        _rend.sprite = sprite3;
        canMove = false;
        OnMoveStart?.Invoke();
        transform.DOMoveX(transform.position.x + (xOffset * leftOrRight), xTime+ScoreManager.Instance.PlayerMoveAdder).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Unset).SetLink(gameObject);
        yield return new WaitForSeconds(xTime * 2.0f);
        _rend.sprite = sprite1;
        OnMoveEnd?.Invoke();
        _rend.flipX = false;
        canMove = true;
    }

    public IEnumerator IHurtCoroutine()
    {
        _rend.color = Color.white;
        if(Time.timeScale != 0)
            StartCoroutine(HurtWhiteCoroutine());
        GameManager.Instance.DoImpulse();
        yield return new WaitForSeconds(0.1f);
        _rend.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        _rend.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        _rend.color = Color.blue;
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
