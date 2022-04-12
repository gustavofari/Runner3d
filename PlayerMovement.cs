using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private Animator animate;
    [SerializeField] private float Speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
    [SerializeField] private float rayRadius;

    private CharacterController controller;
    private GameController gameController;

    public LayerMask layer;

    private float jumpVelocity;
    private bool isMovingLeft;
    private bool isMovingRight;
    private bool isDead;

    public float horizontalSpeed;

    void Awake() {

        controller = GetComponent<CharacterController>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update() {

        OnCollision();

        Vector3 movementDirection = Vector3.forward * Speed;

        if (controller.isGrounded ) {


            if (Input.GetKeyDown(KeyCode.Space)) {

                jumpVelocity = jumpHeight;
            }

            if (Input.GetKeyUp(KeyCode.D) && transform.position.x < 7 && !isMovingRight) {

                isMovingRight = true;
                //Iniciar uma coroutina
                StartCoroutine(RightMove());
            }

            if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -7 && !isMovingLeft) {

                isMovingLeft = true;
                StartCoroutine(LeftMove());
            }

        }
        else {

            jumpVelocity -= gravity;        
        }

        movementDirection.y = jumpVelocity;

        controller.Move(movementDirection * Time.deltaTime);
    }
    IEnumerator LeftMove() {

        for(float index = 0; index < 2; index += 0.1f) {

            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingLeft = false;
    }

    IEnumerator RightMove() {

        for(float index = 0; index < 2; index += 0.1f) {

            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingRight = false;
    }

    void OnCollision() {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) && !isDead) {

            animate.SetTrigger("die");

            jumpHeight = 0; 
            horizontalSpeed = 0;
            Speed = 0;

            isDead = true;

            gameController.Invoke("setGameOver", 2f);
        }
    }
}
