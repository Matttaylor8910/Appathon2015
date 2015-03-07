using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	// Basic Character Attributes
	public int health = 1;			
	public int attackDamage = 1;
	public float moveSpeed = 2f;
	public float applyDamageRadius  = 1;		
	public bool singleTargetAttack = true;	
	public bool rockSkin = false; //immunity to status effects

	protected Animator animator;				
	private Component attackPoint;				
	private bool enemyInRange = false;			



	// Character Initialisation
	void Awake (){

		// Retreive Character GamesaObject References
		animator = GetComponent<Animator> ();
		attackPoint = transform.Find("AttackPoint").GetComponent<Component>();
		
	}

	//Sets the right orintation of character walk left for enemies right for allies/////////////////////////////////////////////////////////////
	void Start () {
		// Flip the Character's Sprite and Collider Direction if they an Enemy
		if (this.tag == "Enemy") {
			Vector3 enemyScale = transform.localScale;
			enemyScale.x *= -1;
			transform.localScale = enemyScale;
		}

	}

	
	void Update () {

		if(enemyInRange == true){
			/////Makes character walk again after attacking
			if(getEnemiesInAttackRadius().Length <= 0){
				enemyInRange = false;
			}
		}

		if (health <= 0) {
			Die();

		/////Sets correct animation
		} else {
			if(enemyInRange){
				animator.SetBool("isAttacking", true);

			} else {
				animator.SetBool("isAttacking", false);
				Move();
			}
		}

	}

	//Applies damage and status efect to enemy///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//This function is called inside the attack animation so that the attack animation and the time that enemies die seems fluid, length of animation 
	//dictates how frequently this is called
	void ApplyDamage(){
			
		Collider2D[] enemies = getEnemiesInAttackRadius();

		if(enemies.Length <= 0){
			enemyInRange = false;
			return;
		}

		if(singleTargetAttack){

			Collider2D closestEnemy = enemies[0];
			float closestDistance = Mathf.Abs(this.gameObject.transform.position.x - enemies[0].gameObject.transform.parent.gameObject.transform.position.x);

			//Finds closest enemy for single target attack
			foreach(Collider2D enemy in enemies){

				float distance = Mathf.Abs(this.gameObject.transform.position.x - enemy.gameObject.transform.parent.gameObject.transform.position.x);

				if(closestDistance > distance){

					closestDistance = distance;
					closestEnemy = enemy;
				}
			}
			closestEnemy.SendMessageUpwards("ReceiveDamage", attackDamage, SendMessageOptions.DontRequireReceiver);

			//Apply status effect if enemy is character and does not have rock skin
			Character enemyCharacter = closestEnemy.gameObject.transform.parent.gameObject.GetComponent<Character>();
			if(enemyCharacter != null && enemyCharacter.rockSkin == false){

				SendMessageUpwards("ApplyStatusEffect", closestEnemy.gameObject.transform.parent.gameObject, SendMessageOptions.DontRequireReceiver);
			}
			return;
		}
			
		//For AOE attacks
		foreach(Collider2D enemy in enemies){

			enemy.SendMessageUpwards("ReceiveDamage", attackDamage, SendMessageOptions.DontRequireReceiver);

			Character enemyCharacter = enemy.gameObject.transform.parent.gameObject.GetComponent<Character>();

			//apply status effect if enemy is character and does not have rock skin
			if(enemyCharacter != null && enemyCharacter.rockSkin == false){

				SendMessageUpwards("ApplyStatusEffect", enemy.gameObject.transform.parent.gameObject, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	//Subtracts from total health////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	void ReceiveDamage(int damage){
		health -= damage;

	}

	//kills characters by playing death animationa nd destroying object///////////////////////////////////////////////////////////////////////////////
	void Die(){

		this.gameObject.SetActive(false);
		GameObject dieEffect = (GameObject)Instantiate(Resources.Load ("Effects/Die"));
		dieEffect.transform.parent = this.gameObject.transform;
		dieEffect.transform.localPosition = new Vector3(0,1,0);
		dieEffect.transform.localScale = new Vector3(1,1,1);
		dieEffect.transform.parent = null;
		Destroy(this.gameObject);
		Destroy (dieEffect, 2);

	}

	//Moves character in the right directon///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	void Move(){
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-0.2f*moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(0.2f*moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	//Returns array of enemies within attack////////////////////////////////////////////////////////////////////////////////////////////////////////
	Collider2D[] getEnemiesInAttackRadius(){

		int layer_bitmask = 0;

		if(this.gameObject.tag == "Ally"){
			layer_bitmask = (1 << 11); 
		}
		else{
			layer_bitmask = (1 << 10);
		}
		
		Vector2 location = new Vector2(this.attackPoint.transform.position.x, this.attackPoint.transform.position.y);
		
		Collider2D[] enemies = Physics2D.OverlapCircleAll(location, applyDamageRadius, layer_bitmask);
		return enemies;
	}

	//Sets move speed, useful for changing movement speed during animations//////////////////////////////////////////////////////////////////////////
	public void setSpeed(float speed){
		moveSpeed = speed;
	}
}
