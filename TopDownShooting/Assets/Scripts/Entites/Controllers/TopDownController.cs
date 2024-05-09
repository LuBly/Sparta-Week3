using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    // 몬스터와 캐릭터 공통적인 기능들을 넣어놓는 곳
    // 액션들을 등록해놓을 수 있는 곳

    public event Action<Vector2> OnMoveEvent; // Action은 무조건 void만 반환해야한다. 아니면 Func
    public event Action<Vector2> OnLookEvent;
    // public event Action OnAttackEvent; >> 어떤 공격을 했는지 추가
    public event Action<AttackSO> OnAttackEvent;

    protected bool IsAttack { get; set; }
    //protected 선언을 한 이유 : 나만 바꾸고 싶지만, 나를 상속받는 친구들도 가져갈 수 있게
    protected CharacterStatHandler stats { get; private set; }
   

    private float timeSinceLastAttack = float.MaxValue;

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        // Todo :: Magic Number 수정 , 공격 속도
        if(timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        if (IsAttack && timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
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

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }

}
