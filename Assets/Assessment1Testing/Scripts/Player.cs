using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SpaceObject
{
    public float thrustSpeed = 1;

    public float rotationalSpeed = 1;

   
    public float maxRotationalSpeed = 10;
    public float maxThrustSpeed = 10;

    public Transform firingPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
	    base.Update();
	    GetInput();   
    }

    void GetInput()
    {
	    float torque = Input.GetAxis("Horizontal");
	    rb.AddTorque(-torque * rotationalSpeed);
		
		if(rb.angularVelocity > maxRotationalSpeed)
		{
			rb.angularVelocity = maxRotationalSpeed;
		}
		if(rb.angularVelocity < -maxRotationalSpeed)
		{
			rb.angularVelocity = -maxRotationalSpeed;
		}
		
	    if(Input.GetKey(KeyCode.W))
	    {
		    rb.AddForce(transform.up*thrustSpeed);
		    if(rb.velocity.magnitude > maxThrustSpeed)
		    {
			    rb.velocity = rb.velocity.normalized*maxThrustSpeed;
		    }
	    }

	    if(Input.GetKeyDown(KeyCode.Space))
	    {
		    FireBullet();
	    }
	    
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

	    if(other.transform.CompareTag("Asteroid"))
	    {
		    Die();
         
	    }
	    
    }

    public void Die()
    {
	    transform.position = Vector3.zero;
	    rb.velocity = Vector2.zero;
	    rb.angularVelocity = 0;
    }

    public Bullet FireBullet()
    {
	    GameObject bullet = Instantiate(bulletPrefab);
	    bullet.transform.position = firingPoint.position;
	    Vector2 playerForce = rb.velocity;
	    Vector2 bulletForce = transform.up * bulletSpeed;
	    bullet.GetComponent<Rigidbody2D>().velocity = playerForce + bulletForce;
	    Destroy(bullet,5f);
	    return bullet.GetComponent<Bullet>();
    }
}
