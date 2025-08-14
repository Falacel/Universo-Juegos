using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class BasedeDatos : MonoBehaviour
{
    private SQLiteConnection db;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string dbPath = Application.persistentDataPath + "/aplicacion.db";
        db = new SQLiteConnection(dbPath);

        db.CreateTable<Jugador>();

        Jugador jugador = new Jugador()
        {
            Nombre = "Jugador",
            Score = Random.Range(0, 1000)
        };
        db.Insert(jugador);

        // Lee todos los jugadores y muestra sus datos
        List<Jugador> players = db.Table<Jugador>().ToList();

        foreach (var p in players)
        {
            Debug.Log($"ID: {p.Id}, Nombre: {p.Nombre}, Puntuación: {p.Score}");
        }
    }

}

    public class Jugador
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Score { get; set; }
    }

