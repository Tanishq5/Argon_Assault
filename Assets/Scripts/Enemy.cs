using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyShipExplosion;
    [SerializeField] GameObject EnemyHitSparks;
    public int score = 10;
    [SerializeField] int EnemyHitPoints = 100;

    ScoreBoard SB;
    GameObject ParentGameobject;

    void Start()
    {
        SB = FindObjectOfType<ScoreBoard>();
        ParentGameobject = GameObject.FindWithTag("SpawnAtRuntime");
        RuntimeEnemyRigidbody();
    }

    private void RuntimeEnemyRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject coll)
    {
        EnemyHitVFX();
        EnemyKillVFX();
    }

    private void EnemyHitVFX()
    {
        GameObject HitVFX = Instantiate(EnemyHitSparks, transform.position, Quaternion.identity);
        HitVFX.transform.parent = ParentGameobject.transform;
        EnemyHitPoints -= 10;
    }

    private void EnemyKillVFX()
    {
        if(EnemyHitPoints <= 0)
        {
            SB.IncreaseScore(score);
            GameObject FX = Instantiate(EnemyShipExplosion, transform.position, Quaternion.identity);
            FX.transform.parent = ParentGameobject.transform;
            Destroy(this.gameObject);
        }
        
    }
}