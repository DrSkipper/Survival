using UnityEngine;

public class MCSAnimController : MonoBehaviour
{
    public float TurnSpeed = 20.0f;

    private Animator _animator;
    private float _walking;
    private float _turning;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _walking = 0.0f;
        _turning = 0.0f;
    }

    void Update()
    {
        _walking = Input.GetAxis("Vertical");
        _animator.SetFloat("Walking", _walking);
        _turning = Input.GetAxis("Horizontal");
        this.transform.Rotate(new Vector3(0.0f, this.TurnSpeed * _turning * Time.deltaTime, 0.0f));
    }
}
