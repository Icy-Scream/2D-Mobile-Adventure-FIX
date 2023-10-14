using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamage
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private bool _resetJump = false;
    [SerializeField] private int _gem = 0;
    [SerializeField] private bool _isJumping = false;
    [SerializeField] public bool _isAttacking = false;
    public bool win {get; set;}
    private GameInput _gameInput;
    public bool _isDead { get; private set; }
    private Rigidbody2D _rigidbody2D;
    public int Health { get; set; } = 4;
    
    private void Awake() {
        _gameInput = gameObject.GetComponent<GameInput>();
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        _gameInput._leftMouseClickInteract += LeftMouseClickInteract;
        _gameInput._jumpButtonPressed += _gameInput__jumpButtonPressed;
    }

    private void OnDestroy() {
        _gameInput._leftMouseClickInteract -= LeftMouseClickInteract;
        _gameInput._jumpButtonPressed -= _gameInput__jumpButtonPressed;
    }

    private void _gameInput__jumpButtonPressed(object sender, System.EventArgs e) {
        if (GroundDetect() == true && _resetJump == false) {
            StartCoroutine(DelayJumpRoutine());
        }
    }

    private void LeftMouseClickInteract(object sender, System.EventArgs e) {
        Attack();
    }

    private void Update() {
        if(!_isDead)
        Movement();
        else if (_isDead) {
            UIManager.Instance.GameOver();
        }
        if(_isJumping)
            _rigidbody2D.AddForce(Vector3.up * _jumpForce);
    }

    private void Attack() {
        if(GroundDetect()) {
            _playerAnimation.IsAttacking();
        }
        else {
            _playerAnimation.IsJumpAttacking();
            return;
        }
        if (_isAttacking && GroundDetect()) {
            _rigidbody2D.velocity = Vector3.zero;
            
        }
    }

    private void Movement() {
        if(!_isAttacking) {
            Vector2 movementVector = _gameInput.GetNormalizedVector();
            if(movementVector.x > 0 || movementVector.x <0)
               movementVector.x =  movementVector.x > 0 ?  1 : -1;
            _playerAnimation.FlipSprite(movementVector.x);
            _playerAnimation.SetMovementParameter(movementVector.x);
            _rigidbody2D.velocity = new Vector2(movementVector.x * _speed, _rigidbody2D.velocity.y);
        }

        if(transform.position.y < -25f) {
            _isDead = true;
            _playerAnimation.SetDeathTrigger();
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this.gameObject, 2f);

        }
    }

    private IEnumerator DelayJumpRoutine() {
        _playerAnimation.SetJumpTrigger();
        _isJumping = true;
        yield return new WaitForSeconds(0.3f);
        _isJumping = false;
        _playerAnimation.ResetJumpTrigger();
        _resetJump = true;
        yield return new WaitForSeconds(0.5f);
        _resetJump = false;
    }

    private bool GroundDetect() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundMask);
        if (hit.collider != null) {
            _isJumping = false;
            return true;
        }
        else
             return false;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.down * 0.8f);
    }

    public void SetGemValue(int value) {
        _gem = value;
    }

    public int GetGemValue() {
        return _gem;
    }

    public void Damage(int d) {
        _playerAnimation.SetDamageTrigger();
       UIManager.Instance.UpdatePlayerHealth(this);
       Health -= d;
        if (Health <= 0) {
            _playerAnimation.SetDeathTrigger();
            _isDead = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this.gameObject,2f);
        }

    }
    
    public void AddGems(int amount) {
        _gem += amount;
        UIManager.Instance.UpdatePlayerGems(this);
    }
}
