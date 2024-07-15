using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MainManuCameraController : MonoBehaviour
{
    [SerializeField]
    private float duration;

    public void LookAT(Transform target)
    {
        transform.DOLookAt(target.position, duration);
    }
}
