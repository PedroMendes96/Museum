using System.Collections.Generic;

namespace Museum
{
    public class ArtPieceFactory : IFactory
    {
        public static readonly string Painting = "Painting";
        public static readonly string Photography = "Photography";
        public static readonly string Sculpture = "Sculpture";

        public object Create(string type)
        {
            ArtPiece artPiece;
            if (type == Painting)
                artPiece = new Painting();
            else if (type == Photography)
                artPiece = new Photography();
            else if (type == Sculpture)
                artPiece = new Sculpture();
            else
                return null;
            return artPiece;
        }

        public object ImportData(string type, Dictionary<string, string> dictionary)
        {
            ArtPiece artPiece;
            if (type == Painting)
                artPiece = new Painting(dictionary);
            else if (type == Photography)
                artPiece = new Photography(dictionary);
            else if (type == Sculpture)
                artPiece = new Sculpture(dictionary);
            else
                return null;
            return artPiece;
        }
    }
}