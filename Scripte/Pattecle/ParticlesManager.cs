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
        particleSystem.Play(); // ��ƼŬ�� �����մϴ�.
        Invoke("StopParticleSystem", particleSystem.main.duration + 0.2f); // ������ �ð� �Ŀ� ��ƼŬ�� �����մϴ�.
    }

    private void StopParticleSystem()
    {
        particleSystem.Stop();
    }
}