
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToDestroyEffect = 2f;
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] float MaxInclusive = 30f;
    [SerializeField] float MinInclusive = -30f;
    [SerializeField] float damage = 5f;
    [SerializeField] GameObject bloodFX;
    [SerializeField] ActualBulletGO bulletGO;

    private void OnEnable()
    {
        bulletGO.OnTrigger += OnTrigger;
    }

    private void OnDisable()
    {
        bulletGO.OnTrigger -= OnTrigger;
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5f);
        float randomY = Random.Range(MinInclusive, MaxInclusive);
        float randomX = Random.Range(MinInclusive, MaxInclusive);
        Vector3 spreadAngle = new Vector3(randomX, randomY, 0);
        transform.Rotate(spreadAngle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*bulletSpeed);
    }
    private void OnTrigger(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }
        if (other.transform.GetComponent<Health>() ==null) 
        {

            return;
            }
        other.transform.GetComponent<Health>()?.TakeDamage(this.gameObject, damage);
        
        
        Destroy(this.gameObject);
    }

    


}
