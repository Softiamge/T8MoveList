// See https://aka.ms/new-console-template for more information
using System;
using T8MoveList;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.VisualBasic.FileIO;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

var options1 = new JsonSerializerOptions
{
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    WriteIndented = true
};

using (TextFieldParser parser = new TextFieldParser("D:\\projects\\T8MoveList\\T8MoveList\\VlYdIWn (1).csv"))
{
    List<Move> moves = new List<Move>();

    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters("\t");
    parser.ReadFields();
    while (!parser.EndOfData)
    {
        Move tom = new Move(parser.ReadFields());
        moves.Add(tom);
    }

    Console.WriteLine(moves.Count());
    foreach (Move move in moves)
    {
        Console.WriteLine( JsonSerializer.Serialize<Move>(move, options1));
    }
}









