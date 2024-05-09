using System;
using UnityEngine;

public enum StatsChangeType
{
    Add, // 0 -> ~만큼 증가
    Multiple, // 1 -> ~% 만큼 증가 or 감소
    Override, // 2 -> 공격력을 999로 변동
}

// 데이터 폴더처럼 사용할 수 있게 만들어주는 Attribute
[Serializable]
public class CharacterStat
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}
