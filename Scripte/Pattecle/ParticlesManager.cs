using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public GameObject sparkEffect;
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = sparkEffect.GetComponent<ParticleSystem>();
        particleSystem.Play(); // 파티클을 시작합니다.
        Invoke("StopParticleSystem", particleSystem.main.duration + 0.2f); // 설정된 시간 후에 파티클을 정지합니다.
    }

    private void StopParticleSystem()
    {
        particleSystem.Stop();
    }
}