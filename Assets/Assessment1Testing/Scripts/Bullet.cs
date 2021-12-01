using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SpaceObject
{
   private void OnCollisionEnter2D(Collision2D other)
   {
      Debug.Log(other.transform.tag);
      if(other.transform.CompareTag("Player"))
      {
         other.transform.GetComponent<Player>().Die();
      }

      if(other.transform.CompareTag("Asteroid"))
      {
         other.transform.GetComponent<Asteroid>().Die();
         
      }
      Die();
   }

   public void Die()
   {
      Destroy(gameObject);
   }
   
}
