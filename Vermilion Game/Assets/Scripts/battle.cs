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
            StartCoroutine(summonEnemies());
        }
    }

    private void updatePlayerPosistion(GameObject Player)
    {
        Player.transform.position = newPos;
    }

    private IEnumerator summonEnemies()
    {
        yield return new WaitForSeconds(4);

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(enemyPre,new Vector3(newPos.x - 10 + 5 * i, newPos.y + 6), Quaternion.identity);
        }
    }
}
