using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawner : MonoBehaviour
{
    public WormFieldController wormFieldController;
    public ObjectPool objectPool;

    public GameObject prefab;

    public int sameTimeWormNumber;
    private int _currentWormNumber;
    private int[] _tempRandomNumber;

    private void Start()
    {
        _tempRandomNumber = new int[sameTimeWormNumber];
    }

    // Update is called once per frame
    void Update()
    {
        WormSpawn();
    }

    private void WormSpawn()
    {
        int randomNumber;
        bool isRandomNumberInArray = false;
        while(_currentWormNumber < sameTimeWormNumber)
        {
            randomNumber = Random.Range(0, wormFieldController.GetListLength() + 1);
            for (int j = 0; j < _tempRandomNumber.Length; j++)
            {
                if(_tempRandomNumber[j] == randomNumber)
                {
                    isRandomNumberInArray = true;
                }
            }
            if (isRandomNumberInArray)
            {
                _tempRandomNumber[_currentWormNumber] = randomNumber;
            }
            objectPool.GetPooledObject(0, wormFieldController.wormOutPoints[randomNumber]);
            _currentWormNumber++;
        }
    }
}
