using System;
using System.Text;
using System.Collections.Generic;

class BoardRenderer
{
    private const char WhiteCell = '-';
    private const char BlackCell = '+';

    private char[,] emptyBoard = null;
    private char[,] populatedBoard = null;

    public BoardRenderer(int size)
    {
        this.emptyBoard = GenerateBoard(size);
    }

    public BoardRenderer(char[,] board)
    {
        this.emptyBoard = board;
    }

    public int Size
    {
        get
        {
            return emptyBoard.GetLength(0);
        }
    }

    private char[,] GenerateBoard(int size)
    {
        char[,] board = new char[size, size];

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (row % 2 == 0)
                {
                    if (col % 2 == 0)
                    {
                        board[row, col] = BlackCell;
                    }
                    else
                    {
                        board[row, col] = WhiteCell;
                    }
                }
                else
                {
                    if (col % 2 == 0)
                    {
                        board[row, col] = WhiteCell;
                    }
                    else
                    {
                        board[row, col] = BlackCell;
                    }
                }
            }
        }

        return board;
    }

    public void PopulateBoard(Dictionary<char, ChessPiece> pieces)
    {
        this.populatedBoard = (char[,])this.emptyBoard.Clone();

        foreach (var piece in pieces)
        {
            this.populatedBoard[piece.Value.X, piece.Value.Y] = piece.Value.Symbol;
        }
    }

    public void WriteMessage(Message msg, int moves = 0)
    {
        string messageAsString = "";
        switch (msg)
        {
            case Message.InvalidMove:
                {
                    messageAsString = "Illegal move!";
                    break;
                }
            case Message.KingWin:
                {
                    messageAsString = string.Format("King wins in {0} turns.", moves);
                    break;
                }
            case Message.KingLose:
                {
                    messageAsString = string.Format("King loses");
                    break;
                }
            default:
                {
                    throw new ArgumentException("Not a recognized message!");
                }
        }

        Console.WriteLine(messageAsString);
        Console.ReadKey();
    }

    public void Render()
    {
        Console.Clear();

        int len = populatedBoard.GetLength(0);

        StringBuilder output = new StringBuilder();

        output.Append("    ");
        for (int index = 0; index < len; index++)
        {
            output.Append(index + " ");
        }
        output.Append('\n');

        string border = string.Format("{0}{1}\n", new string(' ', 3), new string('-', populatedBoard.GetLength(0) * 2 + 1));
        output.Append(border);

        for (int row = 0; row < len; row++)
        {
            output.AppendFormat("{0} | ", row);
            for (int col = 0; col < len; col++)
            {
                output.Append(populatedBoard[col, row] + " ");
            }

            output.Append("|\n");
        }

        output.Append(border);

        Console.Write(output);
    }
}