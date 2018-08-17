using Godot;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class PlayerBody : KinematicBody2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
	
    protected Vector2 GRAVITY_VEC = new Vector2(0, 950);
	protected Vector2 FLOOR_NORMAL = new Vector2(0, -1);
	protected float SLOPE_SLIDE_STOP = 25.0f;
	protected float MIN_ONAIR_TIME = 0.1f;
    protected float WALK_SPEED = 150f;//# pixels/sec;
	protected float JUMP_SPEED = 280f;
	protected float SIDING_CHANGE_SPEED = 10f;


	protected Vector2 linear_vel = new Vector2();
	protected double onair_time = 0;
	protected bool on_floor = false;
	[Export]
	protected NodePath spritePath;
	protected Sprite sprite;

	
	
	
	public override void _Ready()
    {
	    this.sprite = GetNode(spritePath) as Sprite;
    }



	public override void _PhysicsProcess(float delta)
    {
	    onair_time += delta;
	    linear_vel += delta * GRAVITY_VEC;
	    linear_vel = MoveAndSlide(linear_vel, FLOOR_NORMAL, SLOPE_SLIDE_STOP);
	    //if (IsOnFloor())
	    //{
		//    onair_time = 0;
	    //}

	    //on_floor = onair_time < MIN_ONAIR_TIME;
	    var target_speed = 0.0f;
	    if (Input.IsActionPressed("move_left"))
	    {
		    target_speed += -1;
		    sprite.Scale = Vector2.Up+Vector2.Left;
	    }
	    
	    if (Input.IsActionPressed("move_right"))
	    {
		    target_speed += +1;
		    sprite.Scale = Vector2.One;
	    }

	    target_speed *= WALK_SPEED;
        linear_vel.x = Mathf.Lerp(linear_vel.x, target_speed, 0.7f);

        //# Jumping
	    if ( /* on_floor */ ( IsOnFloor() || IsOnWall())  && Input.IsActionPressed("jump"))
	    {
		    linear_vel.y = -JUMP_SPEED;
		   // GD.Print("jump");
            //sound_jump.play()
	    }
	    
	    
	   // GD.Print("on floor: " + IsOnFloor());
	   // GD.Print("on ceiling: " + IsOnCeiling());
	   // GD.Print("on wall: " + IsOnWall());
	    
		   


	//### ANIMATION ###

	//var new_anim = "idle"

	//if on_floor:
	//	if linear_vel.x < -SIDING_CHANGE_SPEED:
	//		sprite.scale.x = -1
	//		new_anim = "run"

	//	if linear_vel.x > SIDING_CHANGE_SPEED:
	//		sprite.scale.x = 1
	//		new_anim = "run"
	//else:
	//	# We want the character to immediately change facing side when the player
	//	# tries to change direction, during air control.
	//	# This allows for example the player to shoot quickly left then right.
	//	if Input.is_action_pressed("move_left") and not Input.is_action_pressed("move_right"):
    //			sprite.scale.x = -1
    //		if Input.is_action_pressed("move_right") and not Input.is_action_pressed("move_left"):
    //			sprite.scale.x = 1
    //
    //		if linear_vel.y < 0:
    //			new_anim = "jumping"
    //		else:
    //			new_anim = "falling"
    //
    //	if shoot_time < SHOOT_TIME_SHOW_WEAPON:
    //		new_anim += "_weapon"
    //
	//if new_anim != anim:
	//	anim = new_anim
	//	$anim.play(anim)
	}
	
	//func _physics_process(delta):

//    public override void _Process(double delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
/*
extends KinematicBody2D

protected GRAVITY_VEC = Vector2(0, 900)
protected FLOOR_NORMAL = Vector2(0, -1)
protected SLOPE_SLIDE_STOP = 25.0
protected MIN_ONAIR_TIME = 0.1
protected WALK_SPEED = 250 # pixels/sec
protected JUMP_SPEED = 480
protected SIDING_CHANGE_SPEED = 10
protected BULLET_VELOCITY = 1000
protected SHOOT_TIME_SHOW_WEAPON = 0.2


var anim=""

#cache the sprite here for fast access (we will set scale to flip it often)
onready var sprite = $sprite

func _physics_process(delta):
	#increment counters


*/
