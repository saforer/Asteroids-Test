using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Bullet : FSprite {
	
	private Vector2 velocity = new Vector2();
    private float direction = 0.0f;
    private float speed = 0.0f;
	
	public bool shouldDestroy = false;
	
	private float maxAge = 0.0f;
    private float createdTime = 0.0f;
    private float destroyTime = 0.0f;
	
	
    public FNode owner;
	
	
	List<FSprite> BulletList = new List<FSprite>();
	List<FSprite> BulletToRemove = new List<FSprite>();
	
	
	public Bullet (string elementName, Vector2 startPosition, float direction, float speed) : base(elementName) {
		this.direction = direction;
        this.speed = speed;
		this.SetPosition(startPosition);
		
		CalculateVelocity(direction, speed);
	}
	
	private void CalculateVelocity (float direction, float speed) {  
			float directionRads = direction * (Mathf.PI / 180);

            this.velocity = new Vector2(speed * Mathf.Cos(directionRads), speed * Mathf.Sin(directionRads));
	}
	
	public void BulletUpdate() {
	
		foreach (FSprite bullet in BulletList) {
	    	bullet.y+=20;
							
		    if (bullet.y >= Futile.screen.halfHeight||bullet.y <= -Futile.screen.halfHeight||bullet.x >= Futile.screen.halfWidth ||bullet.x <= -Futile.screen.halfWidth) {
		      BulletToRemove.Add(bullet);
		    }
		  }	
									
		  foreach (FSprite bullet in BulletToRemove) {
		    BulletList.Remove(bullet);
		    RemoveChild (bullet);	
		  }

                   BulletToRemove.Clear();
		}
	

	    internal void AddBullet(Bullet bullet)  {
            //this.bullets.Add(bullet);
            this.AddChild(bullet);
        }
	
}

