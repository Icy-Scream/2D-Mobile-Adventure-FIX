using UnityEngine;
using System.Collections;
public abstract class Monster : MonoBehaviour {
    [SerializeField] protected Transform[] _wayPoints; 
    public int Speed { get; protected set; }
    public int Health { get; protected set; }
    public int Gems { get; protected set; }
    
    protected bool _inCombat = false;
    protected bool idle;

    protected SpriteRenderer _spriteRenderer;
    protected Vector3 _targetPOS;
    protected IMonsterAnim _monsterAnim;
    

    public virtual void Init() {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _monsterAnim = GetComponentInChildren<IMonsterAnim>();
    }

    private void Start() {
        _targetPOS = _wayPoints[0].position;
        Init();
    }

    public Monster(int speed, int health, int gems) {
        this.Speed = speed;
        this.Health = health;   
        this.Gems = gems;
    }

    public virtual void Update() {
         Movement();
    }

    public virtual void Movement() {
        
        _monsterAnim.InCombat(_inCombat);
         DetectPlayer();

        if (transform.position == _wayPoints[0].position) {
              transform.position = new Vector3(_wayPoints[0].position.x + 0.2f, _wayPoints[0].position.y,_wayPoints[0].position.z);
              idle =  _monsterAnim.TriggerIdle();
            StartCoroutine(IdleRoutine());
                _targetPOS = _wayPoints[1].position;
                _monsterAnim.FlipSprite(false); 
        }
        else if (transform.position == _wayPoints[1].position) {
            transform.position = new Vector3(_wayPoints[1].position.x + 0.2f, _wayPoints[1].position.y, _wayPoints[1].position.z);
            idle =  _monsterAnim.TriggerIdle();
            StartCoroutine(IdleRoutine());
            _targetPOS = _wayPoints[0].position;
                _monsterAnim.FlipSprite(true);    
        }

        if (_inCombat == false && idle == false ) {
            _monsterAnim.Movement(false);
            transform.position = Vector3.MoveTowards(transform.position, _targetPOS, 1 * Time.deltaTime);
        }
        else {
            _monsterAnim.Movement(true);
        }
           
    }

    private void DetectPlayer() {
        var _playerObject = FindObjectOfType<Player>();

        if (_playerObject != null) {
            float _distance = Vector3.Distance(this.transform.position, _playerObject.transform.position);
            if (_distance > 2.5 && _inCombat == true) {
                _inCombat = false;
            }

            Vector3 direction = _playerObject.transform.localPosition - transform.position;
            if (_inCombat && direction.x < 0) {
                _monsterAnim.FlipSprite(true);
            }
            else if (_inCombat && direction.x > 0f) {
                _monsterAnim.FlipSprite(false);
            }

        }
        else { 
             Debug.Log("PLAYER DEAD OR MISSING");
            _inCombat = false;
        }
            

   

    }

    IEnumerator IdleRoutine() {
        yield return new WaitForSeconds(1.5f);
        idle = false;   
    }

    public abstract void Attack();

    public void DamageAnimation() {
        _monsterAnim.TakeDamage();
    }
}
