using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Invector.vCharacterController;

public class BoximonBehaviorMultiplayer : MonoBehaviour
{
    //Mesh del agente enemigo
    public NavMeshAgent agent;

    //Layers para reconocer tierra y jugador
    public LayerMask whatIsGround, whatIsPlayer;

    //player position
    Transform player;

    //enemy health
    float health = 100;

    //Patroling
    Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public static bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //player
    GameObject playerGameObject;

    private void Awake(){
        
    }

    // Start is called before the first frame update
    void Start(){
        playerGameObject = GameObject.FindWithTag("Player");
        player = playerGameObject.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        
    }

    private void Patroling(){
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint(){
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer(){
        agent.SetDestination(player.position);
    }

    private void AttackPlayer(){
        if (!alreadyAttacked){
            ///Attack code here
            agent.SetDestination(player.position);
            transform.LookAt(player);
            playerGameObject.GetComponent<vThirdPersonController>().AddHealth(-10);
            
            ///End of attack code
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
            

    }
    private void ResetAttack(){
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage){
        health -= damage;

        if (health <= 0){
            Invoke(nameof(DestroyEnemy), 0.5f);
            ResetAttack();
            }
    }

    private void DestroyEnemy(){
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision obj){
        if(obj.gameObject.tag == "Player")
        {
            if(obj.gameObject.GetComponent<NewPlayerController>().inAttack)
            {
                DestroyEnemy();
            }
        }
    }
}
