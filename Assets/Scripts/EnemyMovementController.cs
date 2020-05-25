using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = System.Random;

public class EnemyMovementController : MonoBehaviour
{
    public GameObject playerObject;
    public NavMeshAgent navMeshAgent;
    public float enemyRange = 5;
    public Animator animator;
    private float period = 1.5f;
    private AudioManager audioManager;
    private Vector3 basePosition;
    private int isMovingAnimID;
    private int isAttackingAnimID;
    private bool isFollowingPlayer = false;
    private bool isGoingHome = false;
    private float timeSinceLastAttack = 0.25f;
    private Player player;
    private float enemyDamage = 30f;

    private bool isMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            playerObject = GameObject.FindWithTag("Player");
            if (playerObject == null)
                throw new UnassignedReferenceException();
            player = playerObject.GetComponent<Player>();
            audioManager = AudioManager.GetInstance();
            Vector3 v = transform.position;
            this.basePosition = new Vector3(v.x, v.y, v.z);
            navMeshAgent.isStopped = true;
            isMovingAnimID = Animator.StringToHash("IsMoving");
            isAttackingAnimID = Animator.StringToHash("Attack1Trigger");
        }
        catch (UnassignedReferenceException e)
        {
            this.isMenu = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMenu)
            return;
        var playerPos = playerObject.transform.position;
        var myPos = transform.position;

        if (DidArriveAtHome(myPos))
        {
            StayHome();
        }
        else if (ReachedPlayer(myPos, playerPos))
        {
            if (timeSinceLastAttack > period)
            {
                Random random = new Random();
                if (random.Next(100) < 30)
                {
                    audioManager.Play("GiantSound");
                }
                audioManager.Play("EnemyHitSound");
                animator.SetTrigger(isAttackingAnimID);
                player.DealDamage(this.enemyDamage);
                timeSinceLastAttack = 0f;
            }
            else
            {
                timeSinceLastAttack += Time.fixedDeltaTime;
            }

            StayNearPlayer(playerPos, myPos);
        }

        else if (CanFollowPlayer(playerPos))
        {
            FollowPlayer(playerPos);
        }
        else if (IsPlayerUnreachable(playerPos))
        {
            GoBackHome();
        }
    }

    private void GoBackHome()
    {
        isGoingHome = true;
        navMeshAgent.SetDestination(basePosition);
        animator.SetBool(isMovingAnimID, true);
        navMeshAgent.isStopped = false;
        timeSinceLastAttack = 0.25f;
    }

    private void FollowPlayer(Vector3 playerPos)
    {
        this.isFollowingPlayer = true;
        isGoingHome = false;
        navMeshAgent.SetDestination(playerPos);
        navMeshAgent.isStopped = false;
        animator.SetBool(isMovingAnimID, true);
    }

    private void StayNearPlayer(Vector3 playerPos, Vector3 myPos)
    {
        this.transform.LookAt(new Vector3(playerPos.x, myPos.y, playerPos.z));
        animator.SetBool(isMovingAnimID, false);
        isGoingHome = false;
        navMeshAgent.isStopped = true;
    }

    private void StayHome()
    {
        isGoingHome = false;
        isFollowingPlayer = false;
        animator.SetBool(isMovingAnimID, false);
        navMeshAgent.isStopped = true;
    }

    private bool CanFollowPlayer(Vector3 playerPos)
    {
        return Vector3.Distance(basePosition, playerPos) < enemyRange &&
               Mathf.Abs(basePosition.y - playerPos.y) <= 0.3f;
    }

    private bool ReachedPlayer(Vector3 myPos, Vector3 playerPos)
    {
        return player.IsAlive() && isFollowingPlayer && Vector3.Distance(myPos, playerPos) < 0.8f;
    }

    private bool DidArriveAtHome(Vector3 myPos)
    {
        return isGoingHome && Vector3.Distance(navMeshAgent.destination, myPos) < 0.3f;
    }

    private bool IsPlayerUnreachable(Vector3 playerPos)
    {
        return !player.IsAlive() || (isFollowingPlayer && !isGoingHome &&
                                     (Vector3.Distance(basePosition, playerPos) > enemyRange ||
                                      Mathf.Abs(basePosition.y - playerPos.y) > 0.3f));
    }
}