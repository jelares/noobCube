using UnityEngine;

public class CoulombForce : MonoBehaviour
{

    public Transform charge;
    public Material chargemat;

    public Rigidbody charge1;
    public Rigidbody charge2;

    public int q1;
    public int q2;

    public float r;
    public float fmag;
    public float colormod;
    public Color currentColor;
    public Vector3 unit;

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        r = Mathf.Pow((transform.position - charge.position).magnitude, 2);
        Vector3 unit = Vector3.Normalize(transform.position - charge.position);

        fmag = (q2 * q1) / r;

        charge1.AddForce(fmag* unit);
        charge2.AddForce(-fmag* unit);

        colormod = map(Mathf.Abs(fmag), 0, 15, 0, 255);

        currentColor = new Color(0, 0, colormod);
        chargemat.SetColor("_Color", currentColor);

    }
}