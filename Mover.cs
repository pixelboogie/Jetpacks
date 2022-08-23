using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

      public float throttle = 5f;
      public float lifeTime = 45.0f;

      void Update()
      {
            transform.Translate(Vector3.forward * Time.deltaTime * throttle);
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0)
            {
                Destroy(gameObject);
            }
      }

      public void destoryIt()
      {
            Destroy(gameObject);
      }
}