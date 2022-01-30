using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _mRigidbody;
    [FormerlySerializedAs("m_Speed")] public float mSpeed = 5f;
    private AudioSource _audioSource;

    private void Start()
    {
        _mRigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var mInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _mRigidbody.MovePosition(transform.position + mInput * Time.deltaTime * mSpeed);
        if(!mInput.Equals(Vector3.zero))
        {
            _mRigidbody.rotation = Quaternion.LookRotation(mInput);
            _animator.SetBool("running", true);
        }
        else
        {
            _animator.SetBool("running", false);
        }
    }
}
