using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class battle : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner confiner;
    [SerializeField] Vector2 newPos;
    [SerializeField] GameObject enemyPre;
    

    private void Awake()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.m_BoundingShape2D = mapBoundry;
            updatePlayerPosistion(collision.gameObject);
            


            summonEnemies();
        }
    }

    private void updatePlayerPosistion(GameObject Player)
    {
        Player.transform.position = newPos;
    }

    private void summonEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            
        }
    }
}
