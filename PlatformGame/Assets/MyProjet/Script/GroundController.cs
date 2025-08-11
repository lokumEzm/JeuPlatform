using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField]
    private float _groundDistanceTolerance;

    [SerializeField]
    private LayerMask _groundLayerMask;

    private CapsuleCollider _capsuleCollider;

    public bool IsGrounded { get; private set; }

    public float? DistanceToGround { get; private set; }

    private void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        
    }
    
    void Update()
    {
        float sphereCastRadius = _capsuleCollider.radius - 0.1f;
        Vector3 sphereCastOrigin = transform.position + new Vector3(0, _capsuleCollider.radius, 0);

        bool isGroundedBelow = Physics.SphereCast(sphereCastOrigin, sphereCastRadius, Vector3.down, out RaycastHit hitInfo, 1000, _groundLayerMask, QueryTriggerInteraction.Ignore);

        if (isGroundedBelow)

        {
            DistanceToGround = transform.position.y - hitInfo.point.y;
        }
        else
        {
            DistanceToGround = null;
        }

        IsGrounded = isGroundedBelow && DistanceToGround <= _groundDistanceTolerance;
    }
}
