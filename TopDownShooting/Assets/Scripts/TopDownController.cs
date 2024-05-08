using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    // 몬스터와 캐릭터 공통적인 기능들을 넣어놓는 곳
    // 액션들을 등록해놓을 수 있는 곳

    public event Action<Vector2> OnMoveEvent; // Action은 무조건 void만 반환해야한다. 아니면 Func
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool IsAttack { get; set; }
    
    private float timeSinceLastAttack = float.MaxValue;
    
    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        // Todo :: Magic Number 수정
        if(timeSinceLastAttack <= 0.2f)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        if (IsAttack && timeSinceLastAttack > 0.2f)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent();
        }
    }

    // 등록되어있던 이벤트들을 Invoke해주는 것
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

}
