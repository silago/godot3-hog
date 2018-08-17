using Godot;
using System;

public class MainMenu : Control
{    
    [Export]
    protected NodePath StartGameButton;
    
    [Export]
    protected String StartScene;
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    

    public override void _Ready()
    {
        Button startGameBtn = GetNode(StartGameButton) as Button;

        startGameBtn.Connect("button_up", this, "newGame");

        // Called every time the node is added to the scene.
        // Initialization here

    }

    public void newGame()
    {
        //Resource _ = ResourceLoader.Load(StartScene);
        GetTree().ChangeScene(StartScene);
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
