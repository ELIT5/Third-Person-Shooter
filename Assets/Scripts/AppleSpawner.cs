using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public Heal applePrefab;
    private Heal _apple;
    public float delayMin = 3;
    public float delayMax = 9;
    private List<Transform> _spawnerPoints;
    void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if (_apple != null) return;
        if (IsInvoking()) return;
        Invoke("CreateApple", Random.Range(delayMin, delayMax));

    }

    void CreateApple()
    {
        _apple = Instantiate(applePrefab);
        _apple.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].transform.position;
    }
}
