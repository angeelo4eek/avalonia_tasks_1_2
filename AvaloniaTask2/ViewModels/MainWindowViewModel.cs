using AvaloniaTask2_3.Models;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaTask2_3.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ChessPieceViewModel> Pieces { get; }

        [Reactive] public ChessPieceViewModel? SelectedPiece { get; set; }

        public MainWindowViewModel()
        {
            var whiteRook = new Rook(PieceColor.White, new Position(0, 0));
            var blackBishop = new Bishop(PieceColor.Black, new Position(7, 2));
            var whiteQueen = new Queen(PieceColor.White, new Position(3, 3));

            Pieces = new ObservableCollection<ChessPieceViewModel>
            {
                new ChessPieceViewModel(whiteRook),
                new ChessPieceViewModel(blackBishop),
                new ChessPieceViewModel(whiteQueen)
            };

            SelectedPiece = Pieces.FirstOrDefault();
        }
    }
}