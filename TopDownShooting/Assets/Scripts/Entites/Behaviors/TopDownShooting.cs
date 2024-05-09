using System;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController _controller;
    
    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public GameObject testPrefab;

    private void Awake()
    {
        _controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        aimDirection = newAimDirection;
    }

    private void OnShoot()
    {
        CreateProjecttile();
    }

    private void CreateProjecttile()
    {
        // 화살을 생성
        // ToDo : 화살이 실제 날아가게 구현 / 오브젝트 풀을 통한 구조 개선

        float arrowSpeed = 5f;
        // 화살의 방향
        // dir = (마우스 포인터의 위치 - projectileSpawnPosition.position).normalized = 비율 계산
        // 비율 -> 각도 전환 = Math.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // Quaternian.Euler 회전
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 dir = (mousePos - (Vector2)projectileSpawnPosition.position).normalized;
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GameObject arrow = Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.Euler(0,0,rotZ));

        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x,dir.y) * arrowSpeed;
    }
}
