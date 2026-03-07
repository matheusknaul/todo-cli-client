using Terminal.Gui;

Application.Init();

var window = new Window("Todo Configuration")
{
    X = 0,
    Y = 1,
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

var label = new Label("Hello, Terminal.Gui!")
{
    X = Pos.Center(),
    Y = Pos.Center()
};

var label2 = new Label()
{
    Title = "Computed",
    X = Pos.Right(),
    Y = Pos.Center(),
    Width = Dim.Fill(),
    Height = Dim.Percent(50)
};

window.Add(label);
Application.Top.Add(window);

Application.Run();
Application.Shutdown();