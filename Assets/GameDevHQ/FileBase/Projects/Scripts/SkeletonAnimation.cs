using UnityEngine;
public class SkeletonAnimation : MonoBehaviour, IMonsterAnim {
    private Animator _animator;
    private const string WALKINGANIM = "Walking";
    private SpriteRenderer _spriteRenderer;

    public Animator monsterAnim { get => _animator; }
    public SpriteRenderer monsterSpriteRenderer => _spriteRenderer;


    private void Awake() {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool direction) {
        if (direction == true) {
            _spriteRenderer.flipX = true;
        }
        else if (direction == false) {
            _spriteRenderer.flipX = false;
        }
    }

    public void Movement(bool moving) {
        _animator.SetBool(WALKINGANIM, moving);
    }

    public void InCombat(bool InCombat) {
        _animator.SetBool("InCombat", InCombat);
    }

    public void SetSpeed(float speed) {
        _animator.SetFloat("Speed",speed);
    }

    public void TakeDamage() {
        _animator.SetTrigger("Damage");
    }

    public void IsAttacking() {
    }

    public void IsJumpAttacking() {
    }

    public bool TriggerIdle() {
        _animator.SetTrigger("Idle");
        return true;
    }
}
