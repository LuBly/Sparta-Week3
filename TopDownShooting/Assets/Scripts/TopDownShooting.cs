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
        Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }
}
