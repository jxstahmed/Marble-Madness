using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private float spinSpeed = 100f;
    [SerializeField] public int pointValue = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PointCollect>().points += pointValue;
            Destroy(gameObject);
        }
    }

}
