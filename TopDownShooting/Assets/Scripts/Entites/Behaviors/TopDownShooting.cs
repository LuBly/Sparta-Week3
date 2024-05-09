using System;
using UnityEngine;
using Random = UnityEngine.Random;

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

    private void OnShoot(AttackSO attackSO)
    {
        // 이 스크립트에선 원거리 공격만 들고 있을거긴하다.
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;
        // 혹시나 발생할 수 있는 버그에 대한 사전 차단(null값이 들어오면 그냥 나가라)
        if(rangedAttackSO == null) 
        {
            return;
        }
        float projectTilesAngleSpace = rangedAttackSO.multipleProjectilesAngel;
        int numberOfProjectTilesPerShot = rangedAttackSO.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectTilesPerShot / 2f) * projectTilesAngleSpace + 0.5f * rangedAttackSO.multipleProjectilesAngel;

        for(int i = 0; i < numberOfProjectTilesPerShot; i++)
        {
            float angle = minAngle + projectTilesAngleSpace * i;
            // 화살간의 간격에 약간의 장난질 추가 (좀 더 현실감 있게)
            float randomSpread = Random.Range(-rangedAttackSO.spread, rangedAttackSO.spread);

            angle += randomSpread;
            CreateProjecttile(rangedAttackSO, angle);
        }
    }

    private void CreateProjecttile(RangedAttackSO rangedAttackSO, float angle)
    {
        // 화살을 생성
        GameObject obj = Instantiate(testPrefab);

        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(aimDirection, angle), rangedAttackSO);


        /* <내가 만들었던 코드 <화살 날아가기>>
        // 화살의 방향
        // dir = (마우스 포인터의 위치 - projectileSpawnPosition.position).normalized = 비율 계산
        // 비율 -> 각도 전환 = Math.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // Quaternian.Euler 회전
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 dir = (mousePos - (Vector2)projectileSpawnPosition.position).normalized;
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GameObject arrow = Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.Euler(0,0,rotZ));

        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x,dir.y) * arrowSpeed;
        */
    }

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        // 벡터 회전하기 : 쿼터니언 * 벡터 순
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
