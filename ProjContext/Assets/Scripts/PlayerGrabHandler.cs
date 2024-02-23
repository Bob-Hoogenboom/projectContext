using UnityEngine;


/// <summary>
/// Makes the player be able to grab certain objects either from the sides or from below
/// </summary>
public class PlayerGrabHandler : MonoBehaviour
{
    [SerializeField] private LayerMask boxLayer;
    [SerializeField] private float reach = 5;

    [Tooltip("When this checkbox is checked the player will be grabbing downwards instead of sideways")]
    [SerializeField] private bool isOwl;


    private GameObject _box;
    private RaycastHit2D hit;
    private Vector2 grabDir;
    private bool _isHolding = false;


    // Start is called before the first frame update
    private void Start()
    {
        grabDir = isOwl ? Vector2.down : Vector2.right;
    }

    // Update is called once per frame
    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        hit = Physics2D.Raycast(transform.position, grabDir, reach, boxLayer);
    }

    private void OnDrawGizmos()
    {
        grabDir = isOwl ? Vector2.down : Vector2.right;

        Gizmos.color = (isOwl) ? Color.red : Color.blue;
        Gizmos.DrawRay(transform.position, grabDir * reach);
    }

    public void Grab()
    {
        if (hit.collider == null) return;

        _box = hit.collider.gameObject;

        var fixedJoint2D = _box.GetComponent<FixedJoint2D>();

        if (!_isHolding)
        {
            fixedJoint2D.enabled = true;
            fixedJoint2D.connectedBody = this.GetComponent<Rigidbody2D>();
            _isHolding = true;
        }
        else
        {
            fixedJoint2D.enabled = false;
            _isHolding = false;
        }

    }
}


