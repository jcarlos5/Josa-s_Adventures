using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public ParticleSystem ps;

    void Awake()
    {
        ps.Stop();
    }

    public void StartDestroy()
    {
        ps.Play();
        Invoke("DestroyEnemy", 2f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
