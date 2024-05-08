using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    // ���Ϳ� ĳ���� �������� ��ɵ��� �־���� ��
    // �׼ǵ��� ����س��� �� �ִ� ��

    public event Action<Vector2> OnMoveEvent; // Action�� ������ void�� ��ȯ�ؾ��Ѵ�. �ƴϸ� Func
    public event Action<Vector2> OnLookEvent;

    // ��ϵǾ��ִ� �̺�Ʈ���� Invoke���ִ� ��
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
