using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float    m_angle;
    public float    m_minSpeed = 50;
    private float   m_lastTime = 0f;

	void Start ()
    {
        m_angle = m_minSpeed;
	}
	
	void Update ()
    {
        if (Time.fixedTime > (m_lastTime + 4) && m_angle < (m_minSpeed * m_minSpeed))   //Add an amount from 20 to 40 to m_angle every 4 seconds, capped at m_minSpeed squared.
        {
            m_angle += Random.Range(20f, 40f);
            m_lastTime = Time.fixedTime;
        }

        transform.Rotate(Vector3.forward, m_angle * Time.deltaTime);                    //Simply rotates the "Skipping Rope"
	}
}
