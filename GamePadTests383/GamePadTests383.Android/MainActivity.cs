using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

using Microsoft.Xna.Framework;

using GamePadTests383.Core;

namespace GamePadTests383.Android;

[Activity(
    Label = "GamePadTests383",
    MainLauncher = true,
    Icon = "@drawable/icon",
    Theme = "@style/Theme.Splash",
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    ScreenOrientation = ScreenOrientation.SensorLandscape,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden
)]
public class MainActivity : AndroidGameActivity
{
    private GamePadTests383Game _game;
    private View _view;

    /// <summary>
    /// Called when the activity is first created. Initializes the game instance,
    /// retrieves its rendering view, and sets it as the content view of the activity.
    /// Finally, starts the game loop.
    /// </summary>
    /// <param name="bundle">A Bundle containing the activity's previously saved state, if any.</param>
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);

        _game = new GamePadTests383Game();
        _view = _game.Services.GetService(typeof(View)) as View;

        SetContentView(_view);
        _game.Run();
    }
}