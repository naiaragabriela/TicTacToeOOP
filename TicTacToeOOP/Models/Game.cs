namespace TicTacToeOOP.Models;

public class Game
{
    private Player[] players;
    private Board  board;

    public Game()
    {
        players = new Player[2];
        board = new Board();
    }

    public void Start()
    {
        LoadPlayer();

        board.Show();

        RunGame();
    }
    private void RunGame()
    {
        int numerOfRouds = 0;
        bool hasWinner = false;

        do
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (numerOfRouds == 9)
                    break;

                Player currentPlayer = players[i];
                Piece currentPiece = currentPlayer.GetPiece();
                Console.WriteLine("Sua vez: " + currentPlayer.GetName());
                char position = char.Parse(Console.ReadLine());
                bool successSetPosition = board.TrySetPosition(currentPiece, position);

                Console.WriteLine();
                while (!successSetPosition)
                {
                    Console.WriteLine("Erro, posição ocupada, escolha outra");
                    position = char.Parse(Console.ReadLine());
                    successSetPosition = board.TrySetPosition(currentPiece, position);
                }

                Console.WriteLine();
                board.Show();

                if (numerOfRouds >= 5)
                {
                    char piece = board.GetPieceWinner();

                    if (!char.IsWhiteSpace(piece))
                    {
                        if (piece == currentPiece.GetValue())
                        {
                            Console.WriteLine("O Vencedor(a) foi: " + currentPlayer.GetName());
                            hasWinner = true;
                        }
                    }
                }

                numerOfRouds++;
            }

        } while (numerOfRouds < 9 && !hasWinner);

        if (numerOfRouds == 9)
        {
            Console.WriteLine("Deu velha... jogue novamente");
        }
    }
    private void LoadPlayer()
    {
        for (int i = 0; i < players.Length; i++)
        {
            string nameOfPlayer;
            char playerPiece;

            do
            {
                Console.WriteLine("Informe o nome do jogador");
                nameOfPlayer = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(nameOfPlayer));

            Console.WriteLine("Infome qual peça (X ou O) deseja utilizar para jogar");
            
            bool isChar = char.TryParse(Console.ReadLine(), out playerPiece);
            Piece piece = new Piece(playerPiece);

            while (!piece.IsValid() || !isChar)
            {
                Console.WriteLine("Erro: Informe uma peça valida");
                isChar = char.TryParse(Console.ReadLine(), out playerPiece);
                piece = new Piece(playerPiece);
            }

            players[i] = new Player(nameOfPlayer, piece);
        }
    }
}