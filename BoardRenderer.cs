using System;
using System.Text;
using System.Collections.Generic;

class BoardRenderer
{
    private const char WhiteCell = '-';
    private const char BlackCell = '+';

    private char[,] initialBoard = null;

    private char[,] board = null;
    public char[,] Board
    {
        get
        {
            return board;
        }
        private set
        {
            this.board = value;
        }
    }

    public BoardRenderer(int size)
    {
        this.initialBoard = GenerateBoard(size);
    }

    public BoardRenderer(char[,] board)
    {
        this.initialBoard = board;
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
        this.board = (char[,])this.initialBoard.Clone();

        foreach (var piece in pieces)
        {
            this.board[piece.Value.X, piece.Value.Y] = piece.Value.Symbol;
        }
    }

    public void Render()
    {
        Console.Clear();

        int len = board.GetLength(0);

        StringBuilder output = new StringBuilder();

        output.Append("    ");
        for (int index = 0; index < len; index++)
        {
            output.Append(index + " ");
        }
        output.Append('\n');

        string border = string.Format("{0}{1}\n", new string(' ', 3), new string('-', board.GetLength(0) * 2 + 1));
        output.Append(border);

        for (int row = 0; row < len; row++)
        {
            output.AppendFormat("{0} | ", row);
            for (int col = 0; col < len; col++)
            {
                output.Append(board[col, row] + " ");
            }

            output.Append("|\n");
        }

        output.Append(border);

        Console.Write(output);
    }
}