using Avalonia;
using System.Collections.ObjectModel;

namespace TowerDefense.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 800;
    public int Height { get; } = 450;
    private Ball ball;
    private Raquette raquette1;
    private Raquette raquette2;

    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        raquette1 = new Raquette(
            new Point(20, Height / 2 - 40),
            true
        );

        raquette2 = new Raquette(
            new Point(Width - 30, Height / 2 - 40),
            false
        );

        ball = new Ball(new Point(Width/2-32, Height/2-32));
        GameObjects.Add(ball);
        GameObjects.Add(raquette1);
        GameObjects.Add(raquette2);
    }

    protected override void Tick()
    {
        raquette1.Tick();
        raquette2.Tick();
        ball.Tick(Width, Height, raquette1, raquette2);
    }
}
