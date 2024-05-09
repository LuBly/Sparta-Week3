using System;
using System.Collections.Generic;
using UnityEngine;

// 능력치가 변화하는 부분까지
public class CharacterStatHandler : MonoBehaviour
{
    //기본 스텟과 추가 스텟들을 종합해서 최종 스텟을 계산하는 컴포넌트
    [SerializeField] private CharacterStat baseStats; // 정적 데이터
    // 변동되는 동적 데이터를 이곳에서 관리.
    public CharacterStat CurrentStat { get; private set; }
    public List<CharacterStat> statsMopdifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharcterStat();
    }

    private void UpdateCharcterStat()
    {
        // statModifier를 반영하기 위해 baseStat을 먼저 받아옴
        AttackSO attackSO = null;
        if(baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };
        CurrentStat.statsChangeType = baseStats.statsChangeType;
        CurrentStat.maxHealth = baseStats.maxHealth;
        CurrentStat.speed = baseStats.speed;
    }
}