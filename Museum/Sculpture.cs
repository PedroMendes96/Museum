﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Museum
{
    public class Sculpture : ArtPiece
    {
        public static readonly string VolumeProperty = "volume";

        public Sculpture()
        {
        }

        public Sculpture(Dictionary<string, string> dictionary)
        {
        }

        private int id { get; set; }

        public int SculptureId
        {
            get => id;
            set => id = value;
        }

        private double volume { get; set; }

        public double Volume
        {
            get => volume;
            set => volume = value;
        }

        public override void SetDimension(string size)
        {
            Volume = double.Parse(size);
        }

        public override string GetInformation()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            var table = "items";
            var keys = new[] {NameProperty, DescriptionProperty, "exhibitors_id"};
            var values = new[] {Name, Description, Exhibitor.IdExhibitor.ToString()};
            var insertItems = SqlOperations.Instance.Insert(table, keys, values);
            Id = DbConnection.Instance.Execute(insertItems);

            table = "sculptures";
            keys = new[] {VolumeProperty, "items_id"};
            values = new[] {Volume.ToString(CultureInfo.CurrentCulture), Id.ToString()};
            var insertSculptures = SqlOperations.Instance.Insert(table, keys, values);
            DbConnection.Instance.Execute(insertSculptures);
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (table == Items)
                {
                    if (property != NameProperty && property != DescriptionProperty &&
                        property != RoomProperty) error = true;
                }
                else if (table == Sculptures)
                {
                    if (property != VolumeProperty) error = true;
                }
                else
                {
                    error = true;
                }

            if (error)
                Console.WriteLine(@"Falta preencher coisas!!!!");
            else
                UpdateSequence(table, properties, values);
        }
    }
}