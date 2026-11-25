using ChessLogic;
using ChessLogic.Figure;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<Option> OptionSelected;
        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result=gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
        }

        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "White won!",
                Player.Black => "Black won!",
                _ => "Stalemate!"
            };
        }

        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "White",
                Player.Black => "Black",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason razlog,Player trenutniIgrac)
        {
            return razlog switch
            {
                EndReason.Stalemate => $"Stalemate - {PlayerString(trenutniIgrac)} cannot move",
                EndReason.Checkmate => $"Checkmate - {PlayerString(trenutniIgrac)} cannot move",
                EndReason.FiftyMoveRule => "Fifty move rule",
                EndReason.InsufficientMaterial => "Unsufficient material",
                EndReason.ThreefoldRepetition => "Threefold Repetition",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
