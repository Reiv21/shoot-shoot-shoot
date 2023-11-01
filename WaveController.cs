using System;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    
    public int waveNumber;
    public float time;
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 30)
        {
            waveNumber++;
            spawner.spawn = false;
        }
    }
}
