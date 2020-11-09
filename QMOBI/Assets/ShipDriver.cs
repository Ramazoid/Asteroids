using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDriver : MonoBehaviour
{
    private FireGun gun;
    void Start()
    {
        gun = GetComponent<FireGun>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ShipScreen3 = Camera.main.WorldToScreenPoint(transform.position);
        float dx = Input.mousePosition.x - ShipScreen3.x;
        float dy = Input.mousePosition.y - ShipScreen3.y;
        Vector3 dv = new Vector3(dx, 0, dy);
        Vector3 lookatPosition = transform.position + dv;
        transform.LookAt(lookatPosition);

        if (Input.GetMouseButton(1))
        {
            Vector3 dp = transform.position - lookatPosition;
            transform.position += dp / 1000;
        }
        if (Input.GetMouseButtonDown(0))
            gun.Fire();
    }
    private void OnCollisionEnter(Collision col)
    {
        
        
        
        Exploder.Explode(col.collider.gameObject);
        Sounds.PlayRandom("Explosion");
    }
}

