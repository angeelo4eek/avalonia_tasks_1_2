using AvaloniaTask2_3.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace AvaloniaTask2_3.ViewModels
{
    public class ChessPieceViewModel : ViewModelBase
    {
        private readonly ChessPiece _model;

        [Reactive] public string PieceType { get; private set; }
        [Reactive] public string PieceColor { get; private set; }
        [Reactive] public string CurrentPosition { get; private set; }
        [Reactive] public string NewPositionInput { get; set; } = string.Empty;
        [Reactive] public string MoveResult { get; private set; } = string.Empty;

        public ReactiveCommand<Unit, Unit> MakeMoveCommand { get; }

        public ChessPieceViewModel(ChessPiece model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));

            UpdatePropertiesFromModel();

            var canExecuteMakeMove = this.WhenAnyValue(
                vm => vm.NewPositionInput,
                (input) => !string.IsNullOrWhiteSpace(input) && input.Length == 2
            );

            MakeMoveCommand = ReactiveCommand.Create(ExecuteMove, canExecuteMakeMove);

            MakeMoveCommand.ThrownExceptions.Subscribe(ex =>
             {
                 MoveResult = $"Error: {ex.Message}";
             });
        }

        private void ExecuteMove()
        {
            MoveResult = "";
            if (Position.TryParse(NewPositionInput, out Position targetPosition))
            {
                if (_model.MakeMove(targetPosition))
                {
                    MoveResult = $"Ход на {targetPosition} успешен!";
                    UpdatePropertiesFromModel();
                    NewPositionInput = string.Empty;
                }
                else
                {
                    MoveResult = $"Ход на {targetPosition} невозможен для фигуры {_model.GetType().Name}.";
                }
            }
            else
            {
                MoveResult = $"Неверный формат ввода: '{NewPositionInput}'. Используйте формат типа 'A1', 'H8'.";
            }
        }

        private void UpdatePropertiesFromModel()
        {
            PieceType = _model.GetType().Name;
            PieceColor = _model.Color.ToString();
            CurrentPosition = _model.CurrentPosition.ToString();
        }
    }
}