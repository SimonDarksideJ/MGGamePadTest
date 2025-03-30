
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GamePadTests383.Core;

/// <summary>
/// The main class for the game, responsible for managing game components, settings, 
/// and platform-specific configurations.
/// </summary>
public class GamePadTests383Game : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly InputState inputState = new InputState();
    private SpriteFont hudFont;
    private int playerIndex = (int)PlayerIndex.One;
    private Color textDrawColour = Color.White;
    private int textStartPosition = 20;
    private int positionSpacing = 40;
    private string[] gamePadStringsToDraw;

    public GamePadTests383Game()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.IsFullScreen = true;
        _graphics.PreferredBackBufferWidth = 2560;
        _graphics.PreferredBackBufferHeight = 1440;

        gamePadStringsToDraw = new string[]
    {
        "A Button: ",
        "B Button: ",
        "X Button: ",
        "Y Button: ",
        "Start Button: ",
        "Back Button: ",
        "Big Button: ",
        "DPadL Button: ",
        "DPadR Button: ",
        "DPadU Button: ",
        "DPadD Button: ",
        "LBumper Button: ",
        "LThumbstick Button: ",
        "LThumbstick State: ",
        "LTrigger Button: ",
        "LTrigger State: ",
        "RBumper Button: ",
        "RThumbstick Button: ",
        "RThumbstick State: ",
        "RTrigger Button: ",
        "RTrigger State: "
    };
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        hudFont = Content.Load<SpriteFont>("Fonts/Hud");
    }

    protected override void Update(GameTime gameTime)
    {
        inputState.Update(gameTime, GraphicsDevice.Viewport);
        GetGamePadStateValues();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        string state = inputState.CurrentGamePadStates[playerIndex].IsConnected ? "Connected" : "Disconnected";

        string connectedValue = $"GamePad: {state}";
        _spriteBatch.Begin();
        // TODO: Add your drawing code here
        _spriteBatch.DrawString(hudFont, connectedValue, new Vector2(20, textStartPosition), textDrawColour);

        for (int i = 0; i < gamePadStringsToDraw.Length; i++)
        {
            _spriteBatch.DrawString(hudFont, gamePadStringsToDraw[i], new Vector2(20, GetTextPositionForIndex(i + 1)), textDrawColour);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void GetGamePadStateValues()
    {
        gamePadStringsToDraw[0] = $"A Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.A)}";
        gamePadStringsToDraw[1] = $"B Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.B)}";
        gamePadStringsToDraw[2] = $"X Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.X)}";
        gamePadStringsToDraw[3] = $"Y Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.Y)}";

        gamePadStringsToDraw[4] = $"Start Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.Start)}";
        gamePadStringsToDraw[5] = $"Back Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.Back)}";
        gamePadStringsToDraw[6] = $"Big Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.BigButton)}";

        gamePadStringsToDraw[7] = $"DPadL Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.DPadLeft)}";
        gamePadStringsToDraw[8] = $"DPadR Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.DPadRight)}";
        gamePadStringsToDraw[9] = $"DPadU Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.DPadUp)}";
        gamePadStringsToDraw[10] = $"DPadD Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.DPadDown)}";

        gamePadStringsToDraw[11] = $"RBumper Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.RightShoulder)}";
        gamePadStringsToDraw[12] = $"RThumbstick Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.RightThumbstickDown)}";
        gamePadStringsToDraw[13] = $"RThumbstick State: {inputState.CurrentGamePadStates[playerIndex].ThumbSticks.Right}";
        gamePadStringsToDraw[14] = $"RTrigger Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.RightTrigger)}";
        gamePadStringsToDraw[15] = $"RTrigger State: {inputState.CurrentGamePadStates[playerIndex].Triggers.Right}";

        gamePadStringsToDraw[16] = $"LBumper Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.LeftShoulder)}";
        gamePadStringsToDraw[17] = $"LThumbstick Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.LeftThumbstickDown)}";
        gamePadStringsToDraw[18] = $"LThumbstick State: {inputState.CurrentGamePadStates[playerIndex].ThumbSticks.Left}";
        gamePadStringsToDraw[19] = $"LTrigger Button: {inputState.CurrentGamePadStates[playerIndex].IsButtonDown(Buttons.LeftTrigger)}";
        gamePadStringsToDraw[20] = $"LTrigger State: {inputState.CurrentGamePadStates[playerIndex].Triggers.Left}";
    }

    private int GetTextPositionForIndex(int index)
    {
        return textStartPosition + positionSpacing * index;
    }
}
