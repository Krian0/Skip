using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody        m_rb;
    private SphereCollider   m_col;
    private AudioSource      m_audio;

    public LayerMask        m_groundLayers;

    public AudioClip        m_jumpSound;
    public AudioClip        m_hitSound;
    public GameObject       m_rope;

    void Start ()
    {
        m_rb = GetComponent<Rigidbody>();
        m_col = GetComponent<SphereCollider>();
        m_audio = GetComponent<AudioSource>();
    }

    void Update ()
    {
        bool SpacePressed = Input.GetKey(KeyCode.Space);
        bool ScreenTapped;

        if (Input.touchCount > 0)
            ScreenTapped = true;
        else
            ScreenTapped = false;


        if (IsGrounded() == true && (SpacePressed || ScreenTapped))
        {
            m_rb.AddForce(Vector3.up * 5, ForceMode.Impulse);           //Jump and play jump sound if input is either spacebar or a screen tap.
            m_audio.PlayOneShot(m_jumpSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == m_rope.tag)            //Play hit sound if the player is hit by the rope, reset rope rotation speed.
        {
            m_audio.PlayOneShot(m_hitSound);
            RotationScript ropeRot = other.GetComponentInParent<RotationScript>();
            ropeRot.m_angle = ropeRot.m_minSpeed;
        }
    }

    //Checks if the player sphere is touching the ground. Returns bool.
    private bool IsGrounded()
    {
        return Physics.CheckSphere(m_col.bounds.center, m_col.radius * 1.2f, m_groundLayers);
    }
}
