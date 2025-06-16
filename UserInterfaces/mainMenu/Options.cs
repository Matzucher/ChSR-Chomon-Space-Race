using Godot;
using System;

public partial class Options : VBoxContainer
{
    [Export]
    public bool IsExpanded = true;

    private enum State
    {
        Open,
        Close,
        Opening,
        Closing
    }

    private bool _init = false;
    private State _state;
    private Vector2 _maxSize;
    private Vector2 _lastSize;

    private VBoxContainer _vBox;

    public override void _Ready()
    {
        _vBox = this;
        _state = State.Open;
        GD.Print("Test!");
    }

    public void expand()
    {
        IsExpanded = !IsExpanded;
        _state = IsExpanded ? State.Opening : State.Closing;
        GD.Print("Test2!");
    }

    public override void _Process(double delta)
    {
        if (!_init)
        {
            _maxSize = _vBox.Size;
            _lastSize = _vBox.Size;
            _vBox.CustomMinimumSize = new Vector2(_vBox.CustomMinimumSize.X, _maxSize.Y);
            _init = true;
        }

        if (_state == State.Closing)
        {
            _vBox.SizeFlagsVertical = Control.SizeFlags.ShrinkBegin;

            if (_vBox.CustomMinimumSize.Y > 0)
            {
                double newY = Mathf.Lerp(_lastSize.Y, 0, 0.1);
                _vBox.CustomMinimumSize = new Vector2(_vBox.CustomMinimumSize.X, newY);
                _lastSize = _vBox.CustomMinimumSize;
            }
            else if (_vBox.CustomMinimumSize.Y == 0)
            {
                _vBox.SizeFlagsVertical = Control.SizeFlags.Fill;

                foreach (Node child in _vBox.GetChildren())
                {
                    if (child is Control control)
                    {
                        control.Visible = IsExpanded || control == GetNode("show");
                    }
                }

                _state = State.Close;
            }
        }
        else if (_state == State.Opening)
        {
            _vBox.SizeFlagsVertical = Control.SizeFlags.ShrinkBegin;

            foreach (Node child in _vBox.GetChildren())
            {
                if (child is Control control)
                {
                    control.Visible = IsExpanded || control == GetNode("show");
                }
            }

            if (_vBox.CustomMinimumSize.Y < _maxSize.Y)
            {
                double newY = Mathf.Lerp(_lastSize.Y, _maxSize.Y, 0.1);
                _vBox.CustomMinimumSize = new Vector2(_vBox.CustomMinimumSize.X, newY);
                _lastSize = _vBox.CustomMinimumSize;
            }
            else if (_vBox.CustomMinimumSize.Y == _maxSize.Y)
            {
                _vBox.SizeFlagsVertical = Control.SizeFlags.Fill;
                _state = State.Open;
            }
        }
    }
}