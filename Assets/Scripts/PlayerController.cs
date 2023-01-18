using UnityEngine;

public class PlayerController : MonoBehaviour{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float baseSpeed = 20f;

    private Rigidbody2D _rigidbody2D;
    private SurfaceEffector2D _surfaceEffector2D;
    private bool _canMove = true;

    private void Start(){
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update(){
        if (!_canMove) return;
        RotatePlayer();
        RespondToBoost();
    }

    public void DisableControls(){
        _canMove = false;
    }

    private void RespondToBoost(){
        _surfaceEffector2D.speed = Input.GetKey(KeyCode.UpArrow) ? boostSpeed : baseSpeed;
    }

    private void RotatePlayer(){
        if (Input.GetKey(KeyCode.LeftArrow)){
            _rigidbody2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            _rigidbody2D.AddTorque(-torqueAmount);
        }
    }
}