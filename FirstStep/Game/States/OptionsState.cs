﻿namespace FirstStep.Game.States.Options
{
    using Controls;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// Состояние нахождения на экране настроек.
    /// </summary>
    public class OptionsState : State
    {
        /// <summary>
        /// Набор элентов управления.
        /// </summary>
        private readonly ContolCollection _contols;

        /// <summary>
        /// Несохраненные настройки доски.
        /// </summary>
        private readonly GameSettings _tempSettings;
        
        public OptionsState()
        {
            _tempSettings = Settings.Clone();
            _contols = ContolCollection.Create()
                .AtCoords(ControlPosition.Center)
                .SetSize(6)
                .AddControl(
                    new NumericUpDown("Board height", i => _tempSettings.BoardHeight = i, Settings.BoardHeight, 30, 1))
                .AddControl(
                    new NumericUpDown("Board width", i => _tempSettings.BoardWidth = i, Settings.BoardWidth, 30, 2))
                .AddControl(new NumericUpDown("Gold amount", i => _tempSettings.GoldAmount = i, Settings.GoldAmount))
                .AddControl(
                    new NumericUpDown("Robots amount", i => _tempSettings.RobotsAmount = i, Settings.RobotsAmount))
                .AddControl(new NumericUpDown("Holes amount", i => _tempSettings.HolesAmount = i, Settings.HolesAmount))
                .AddControl(new NumericUpDown("Map seed", i => _tempSettings.Seed = i, Settings.Seed, minValue: -1))
                .AddControl(new CheckBox("Smart robots", b => _tempSettings.SmartRobots = b, Settings.SmartRobots))
                .AddControl(
                    new Button(
                        "Save",
                        button =>
                            {
                                Settings = _tempSettings;
                                button.Caption = "Settings saved";
                            }))
                .AddControl(new Button("Back", () => NewState = new MainMenuState()))
                .WithBackground(Color.FromNonPremultiplied(0, 0, 0, 0));
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public override void Draw()
        {
            _contols.Draw();
        }

        /// <summary>
        /// Выполнить обновление.
        /// </summary>
        protected override void DoUpdate()
        {
            _contols.Update();
        }
    }
}