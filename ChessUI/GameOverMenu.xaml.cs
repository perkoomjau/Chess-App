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
                Player.White => "Beli je pobedio!",
                Player.Black => "Crni je pobedio!",
                _ => "Remi!"
            };
        }

        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "Beli",
                Player.Black => "Crni",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason razlog,Player trenutniIgrac)
        {
            return razlog switch
            {
                EndReason.Stalemate => $"Pat - {PlayerString(trenutniIgrac)} ne moze da se pomeri",
                EndReason.Checkmate => $"Sahmat - {PlayerString(trenutniIgrac)} ne moze da se pomeri",
                EndReason.FiftyMoveRule => "Pravilo 50 poteza",
                EndReason.InsufficientMaterial => "Nedovoljno materijala",
                EndReason.ThreefoldRepetition => "Tri puta se ponovio potez",
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
