using Avalonia;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using static TowerDefense.Keyboard;

namespace TowerDefense.ViewModels;

public partial class Raquette : GameObject {
    [ObservableProperty]
    private Point velocity = new Point(0, 5);

    public bool p1;
    private Key keyUp;
    private Key keyDown;

    public Raquette(Point location) : base(location) {

    }
    public Raquette(Point location, bool p1) : base(location) {
        this.p1 = p1;
        if(p1){
            this.keyUp = Key.Z;
            this.keyDown = Key.S;
        }
        else{
            this.keyUp = Key.Up;
            this.keyDown = Key.Down;
        }
    }

    public void Tick() 
    {
        double y = Location.Y;

        if (IsKeyDown(keyUp)){
            y -= Velocity.Y;
        }

        if (IsKeyDown(keyDown)){
            y += Velocity.Y;
        }

        Location = new Point(Location.X, y);
    }
}
