using UnityEngine;

public class Parallex : MonoBehaviour
{
  private float length, startpos;
  public float pos;
  public float parallaxEffect;

  void Start()
  {
    startpos = transform.position.x;
    length = GetComponent<SpriteRenderer>().bounds.size.x;
  }

  private void FixedUpdate()
  {
    pos += 1 * Time.deltaTime;
    // float temp = pos * (1 - parallaxEffect);
    float dist = pos * parallaxEffect;

    transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

    if (dist > startpos + length)
    {
      pos = 0;
    }
    else if (dist < startpos - length)
    {
      pos = 0;
    }
  }
}