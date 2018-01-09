using System;
using System.Collections;
using System.Collections.Generic;

namespace Museum
{
    public class Room
    {
        public static readonly string SizeProperty = "size";
        public static readonly string DescriptionProperty = "description";
        public static readonly string EventProperty = "events_id";

        public Room()
        {
            ArtPiecesList = new List<ArtPiece>();
        }

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        private int size { get; set; }

        public int Size
        {
            get => size;
            set => size = value;
        }

        private string description { get; set; }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public IList ArtPiecesList { get; set; }

        public void Save()
        {
            var insertRoom = "INSERT INTO rooms (size,description) VALUES (" + size + ", " + description + ")";
            var dbConnection = new DBConnection();
            dbConnection.Execute(insertRoom);
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (properties[i] != SizeProperty && properties[i] != DescriptionProperty &&
                    properties[i] != EventProperty)
                    error = true;
            if (error)
            {
                Console.WriteLine("Nao e possivel efetuar essa operacao!");
            }
            else
            {
                var update = "UPDATE INTO rooms SET ";
                for (var i = 0; i < properties.Length; i++)
                    if (i == properties.Length - 1)
                        update += properties[i] + "=" + values[i];
                    else
                        update += properties[i] + "=" + values[i] + ", ";
                update += " WHERE id=" + id;
                var dbConnection = new DBConnection();
                dbConnection.Execute(update);
            }
        }
    }
}