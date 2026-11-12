using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TowerDefense.ViewModels;

// représente un objet affichable sur l'interface
public abstract partial class GameObject : ViewModelBase
{
    [ObservableProperty]
    private Point _location;

    protected GameObject(Point location)
    {
        Location = location;
    }
}