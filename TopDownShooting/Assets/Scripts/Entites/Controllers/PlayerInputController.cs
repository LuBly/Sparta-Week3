using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController 
{
    private Camera camera;

    protected override void Awake()
    {
        // 부모의 Awake도 빼먹지말고 실행하라는 의미
        base.Awake();
        camera = Camera.main; // mainCamera 태그 붙어있는 카메라를 가져온다
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        // 실제 움직이는 처리는 여기서 하는게 아니라 PlayerMovement에서 함
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnFire(InputValue value)
    {
        IsAttack = value.isPressed;
    }
}
