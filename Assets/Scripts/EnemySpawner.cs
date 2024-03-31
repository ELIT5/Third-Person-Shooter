using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefaab;
    private List<Transform> _spawnerPoints;
    private List<EnemyAI> _enemies;
    public int enemiesMaxCount = 5;
    public float delay = 5;
    private float _timeLastSpawned;
    public PlayerController player;
    public List<Transform> TargetPoints;
    void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();
    }


    public void Update()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies[i].GetComponent<AudioSource>().enabled = false;
            _enemies.RemoveAt(i);
            --i;
        }
        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;
        CreateEnemy();
    }

    void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefaab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].transform.position;
        _enemies.Add(enemy);
        enemy.player = player;
        enemy.TargetPoints = TargetPoints;
        _timeLastSpawned = Time.time;
    }
}
