using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualBulletGO : MonoBehaviour
{
    public event Action<Collider> OnTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        OnTrigger?.Invoke(other);
    }
}
