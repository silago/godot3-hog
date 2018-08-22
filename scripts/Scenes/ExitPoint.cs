using Godot;
using System;
using Object = Godot.Object;

public class ExitPoint : Node2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    
    [Export] 
    protected String SceneToLoad;
    protected Area2D Area;

    public override void _Ready()
    {

        // Called every time the node is added to the scene.
        // Initialization here

    }
    
    public void _on_Area2D_body_entered(Node2D obj)
    {
        if (obj.GetMeta("name").ToString() == "player")
        {
            GetTree().ChangeScene(SceneToLoad);
        }
        
    }


//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
