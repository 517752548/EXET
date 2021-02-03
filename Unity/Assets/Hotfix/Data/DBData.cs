using System;
using System.Collections;
using System.Collections.Generic;
using UltraLiteDB;
using UnityEngine;

namespace ETHotfix
{
    public class DBData: Component
    {
        private UltraLiteDatabase db;
        public void Init()
        {
            // Open database (or create if doesn't exist)
            db = new UltraLiteDatabase("MyData.db");
            return;
            // Get a collection
            var col = db.GetCollection(this.GetType().Name);
            
            // Create a new character document
            var character = new BsonDocument();
            character["Name"] = "John Doe";
            character["Level"] = 1;
            character["IsActive"] = true;
            // Insert new customer document (Id will be auto generated)
            BsonValue id = col.Insert(character);
            // new Id has also been added to the document at character["_id"]

            // Update a document inside a collection
            character["Name"] = "Joana Doe";
            col.Update(character);

            // Insert a document with a manually chosen Id
            var character2 = new BsonDocument();
            character2["_id"] = 10;
            character2["Name"] = "Test Bob";
            character2["Level"] = 10;
            character2["IsActive"] = true;
            col.Insert(character2);
            // Load all documents
            List<BsonDocument> allCharacters = new List<BsonDocument>(col.FindAll());

            // Delete something
            col.Delete(10);

            // Upsert (Update if present or insert if not)
            col.Upsert(character);

            // Don't forget to cleanup!
            db.Dispose();
        }

        public void InsertData<T>(T t) where T : BaseDBData
        {
            var col = db.GetCollection(typeof(T).Name);
            col.Insert(t.ToBsonDocument());
        }
        
    }
}