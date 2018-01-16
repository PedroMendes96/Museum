using System.Collections.Generic;

namespace Museum
{
    public class ArtpieceFactory : IFactory
    {
        public static readonly string painting = "Painting";
        public static readonly string photography = "Photography";
        public static readonly string sculpture = "Sculpture";

        public object Create(string type)
        {
            ArtPiece artPiece;
            if (type == painting)
                artPiece = new Painting();
            else if (type == photography)
                artPiece = new Photography();
            else if (type == sculpture)
                artPiece = new Sculpture();
            else
                return null;
            return artPiece;
        }

        public object ImportData(string type,Dictionary<string, string> dictionary)
        {
            ArtPiece artPiece;
            if (type == painting)
                artPiece = new Painting(dictionary);
            else if (type == photography)
                artPiece = new Photography(dictionary);
            else if (type == sculpture)
                artPiece = new Sculpture(dictionary);
            else
                return null;
            return artPiece;
        }
    }
}