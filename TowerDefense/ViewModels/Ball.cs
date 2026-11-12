using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TowerDefense.ViewModels;

public partial class Ball : GameObject {
    [ObservableProperty]
    private Point velocity = new Point(3, 3);

    public const double Size = 64;

    public Ball(Point location) : base(location) {

    }

    public void Tick(double width, double height, Raquette p1, Raquette p2) {
        double x = Location.X + Velocity.X;
        double y = Location.Y + Velocity.Y;

        // hit top or bottom walls
        if(y <= 0 || y + Size >= height){
            Velocity = new Point(Velocity.X, -Velocity.Y);
        }

        // hit left paddle
        if(Velocity.X < 0 &&
            x <= p1.Location.X + 10 &&
            x + Size >= p1.Location.X &&
            y + Size >= p1.Location.Y &&
            y <= p1.Location.Y + 80){

            Velocity = new Point(-Velocity.X, Velocity.Y);
        }

        // hit right paddle
        if(Velocity.X > 0 &&
            x + Size >= p2.Location.X &&
            x <= p2.Location.X + 10 &&
            y + Size >= p2.Location.Y &&
            y <= p2.Location.Y + 80){

            Velocity = new Point(-Velocity.X, Velocity.Y);
        }

        Location = new Point(x, y);
    }
}
