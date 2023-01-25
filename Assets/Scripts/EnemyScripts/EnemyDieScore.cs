using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieScore : MonoBehaviour
{
    [field: SerializeField] public int _enemyDieCount { get; private set; }

    public void PlusEnemyDie()
    {
        _enemyDieCount += 1;
    }
}
