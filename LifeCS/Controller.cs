using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    // ĵ���� - �����е� ������ ��ġ ũ�⸸ŭ ������ �̹��� - �����е� ��� - ���̽�ƽ
    // ��ũ��Ʈ�� ĵ������, �����е� ��濡 ���̽�ƽ ����ִ� ������, ���̽�ƽ

    public enum EventHandle { Click, Drag }
    public EventHandle ePrevEvent;

    //private RectTransform m_BackGround;

    public GameObject joyStickBackGround;
    public GameObject joyStick;

    private RectTransform transJoyStickBackGround;
    private RectTransform transJoyStick;

    public Vector2 vecJoystickValue { get; private set; }
    public Vector3 vecJoyRotValue { get; private set; }

    private float fRadius;

    public enum PlayerState { Idle, Attack, Move, End }
    public PlayerState ePlayerState { get; private set; }


    private void Awake()
    {
        Init();
    }

    #region event
    public void OnPointerClick(PointerEventData eventData)
    {
        SetPlayerState(PlayerState.Idle);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CallJoyStick(eventData);
        SetHandleState(EventHandle.Click);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joyStickBackGround.SetActive(false);

        if (ePrevEvent == EventHandle.Drag)
            return;

        SetPlayerState(PlayerState.Attack);
        SetHandleState(EventHandle.Click);
    }

    public void OnDrag(PointerEventData eventData)
    {
        JoyStickMove(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        JoyStickMoveEnd(eventData);
    }
    #endregion

    private void Init()
    {
        transJoyStickBackGround = joyStickBackGround.GetComponent<RectTransform>();
        transJoyStick = joyStick.GetComponent<RectTransform>();
        fRadius = transJoyStickBackGround.rect.width * 0.5f; //���̽�ƽ�� �ൿ�ݰ� ���

        joyStick.SetActive(true);
        joyStickBackGround.SetActive(false);
    }

    private void JoyStickMoveEnd(PointerEventData eventData)
    {
        transJoyStick.position = eventData.position;
        joyStickBackGround.SetActive(false);

        SetHandleState(EventHandle.Click);
        SetPlayerState(PlayerState.Idle);
    }

    private void CallJoyStick(PointerEventData eventData)
    {
        joyStickBackGround.transform.position = eventData.position;
        joyStick.transform.position = eventData.position;
        joyStickBackGround.SetActive(true);
    }

    private void JoyStickMove(PointerEventData eventData)
    {
        vecJoystickValue = eventData.position - (Vector2)transJoyStickBackGround.position;

        vecJoystickValue = Vector2.ClampMagnitude(vecJoystickValue / 32 /*�巡�� �̵���*/, fRadius);
        transJoyStick.localPosition = vecJoystickValue /* / 2 ���̽�ƽ �ִ� �ൿ�ݰ�*/;

        vecJoyRotValue = new Vector3(transJoyStick.localPosition.x, 0f, transJoyStick.localPosition.y);

        SetHandleState(EventHandle.Drag);
        SetPlayerState(PlayerState.Move);
    }

    private void SetHandleState(EventHandle _handle)
    {
        ePrevEvent = _handle;
    }

    private void SetPlayerState(PlayerState _state)
    {
        ePlayerState = _state;
    }
}