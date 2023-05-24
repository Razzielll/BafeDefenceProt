using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float attackRange = 0.2f;
    [SerializeField] float attackPerSecond = 1f;
    [SerializeField] float agroRadius = 10f;
    Health health;
    Fighter fighter;
    Mover mover;
    Animator animator;
    float timer = 0;

    bool playerOnBase =false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnPlayerEnterBase += Instance_OnPlayerEnterBase;
        playerOnBase = GameManager.Instance.GetIsPlayerOnBase();
        health = GetComponent<Health>();
        fighter = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
        animator = GetComponent<Animator>();
    }

    private void Instance_OnPlayerEnterBase(bool isOnBase)
    {
        playerOnBase = isOnBase;
    }

    // Update is called once per frame
    void Update()
    {
        timer +=Time.deltaTime;
        if (health.IsDead())
        {
            mover.CancelMoveAction();
            return;
        }
        if (playerOnBase)
        {
            mover.CancelMoveAction();
            return;
        }

        if (fighter.GetPlayer() == null)
        {            
            return ;
        }
        if(Vector3.Distance( fighter.GetPlayer().position,transform.position) < attackRange && timer > 1/attackPerSecond)
        {
            animator.SetTrigger("Attack");
            timer = 0;
        }
        if(Vector3.Distance(fighter.GetPlayer().position, transform.position) < agroRadius)
        {
            mover.MoveTo(fighter.GetPlayer().position);
        }
            
    }
}
