using UnityEngine;

[RequireComponent(typeof(Animator))]
public class KnightController : MonoBehaviour
{

    Animator _animator;
    [SerializeField]
    [Range(1,6)]
    float speed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        float get_x = Input.GetAxisRaw("Horizontal");
        float get_jump = Input.GetAxisRaw("Vertical");
        float get_attack = Input.GetAxisRaw("Jump");
        gameObject.transform.Translate(0, 0, 0);

        _animator.SetInteger("isMoving", 0);
        _animator.SetBool("isJumping", false);

        if (get_jump != 0)
        {
            gameObject.transform.Translate(0, get_jump * Time.deltaTime, 0);
            _animator.SetBool("isJumping", true);
        }
        if (get_x != 0)
        {
            gameObject.transform.Translate(speed * get_x * Time.deltaTime, 0, 0);
            _animator.SetInteger("isMoving", 1);
        }
        if (get_attack != 0)
        {
            _animator.SetBool("toAttack", true);
        }
        else
        {
            _animator.SetBool("toAttack", false);
        }

    }
}
