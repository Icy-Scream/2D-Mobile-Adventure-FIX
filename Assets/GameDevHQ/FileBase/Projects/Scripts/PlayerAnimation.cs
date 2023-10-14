using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private Animator _swordAnimation;
    [SerializeField] private SpriteRenderer _swordRenderer;
    [SerializeField] private Player _player;
    private const string SWORDANIM = "SwordAnim";
    private const string MOVESPEED = "Move";
    private const string JUMPTRIGGER = "Jump";
    private const string ATTACKING = "Attack";
    private const string JUMPATTACK = "JumpAttack";
    private SpriteRenderer _spriteRenderer;
    private void Awake() {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }   

    public void FlipSprite(float direction) {
        if (direction == -1) {
            _spriteRenderer.flipX = true;
            _swordRenderer.flipY = true;
        }
        else if (direction > 0) {
                _spriteRenderer.flipX = false;
                _swordRenderer.flipY = false;
        }
    }

    public void IsDoneAttacking() {
        _player._isAttacking = false;
    }

    public void IsAttacking() {
            _swordAnimation.SetTrigger(SWORDANIM);
            _animator.SetTrigger(ATTACKING);
            _player._isAttacking = true;
    }

    public void IsJumpAttacking() {
        _animator.SetTrigger(JUMPATTACK);
        _swordAnimation.SetTrigger(SWORDANIM);
    }

    public void SetJumpTrigger() {
       _animator.SetTrigger(JUMPTRIGGER);
    }

    public void ResetJumpTrigger() {
        _animator.ResetTrigger(JUMPTRIGGER);
    }

    public void SetMovementParameter(float speed) {
        _animator.SetFloat(MOVESPEED, Mathf.Abs(speed));
    }

    public void SetDamageTrigger() {
        _animator.SetTrigger("Damage");
    }

    public void SetDeathTrigger() {
        _animator.SetTrigger("Death");
    }
}
