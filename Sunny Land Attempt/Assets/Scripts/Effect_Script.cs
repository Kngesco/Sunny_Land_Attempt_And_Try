using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Script : MonoBehaviour
{
    [SerializeField]
    float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
