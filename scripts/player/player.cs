using Godot;
using System;

public class Player : Node
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    [Export] protected NodePath _bodyPath;
    public Node2D Body; 
    public override void _Ready()
    {
        Body = GetNode(_bodyPath) as Node2D;
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}


