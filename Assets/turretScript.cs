using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class turretScript : MonoBehaviour
{
    [FormerlySerializedAs("firePos")] public Vector3 fireOffset;
    public GameObject bullet;
    public float delay=1;
    private void OnEnable()
    {
        StartCoroutine(FireLoop());
    }

    private IEnumerator FireLoop()
    {
        yield return new WaitForSeconds (delay);
        
        Instantiate(bullet,new Vector3(transform.position.x +fireOffset.x,transform.position.y +fireOffset.y,transform.position.z +fireOffset.z) , bullet.transform.localRotation);
        StartCoroutine(FireLoop());
    }
}
