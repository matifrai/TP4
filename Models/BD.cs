using Dapper;
using Microsoft.Data.SqlClient;
using TP4.Models;

namespace TP4.Models;

public class BD{
    private string _connectionString = @"Server=localhost; 
    DataBase=TP04; Integrated Security=True;TrustServerCertificate=True;";


    public List<Jugadores> obtenerTodos(){
        List<Jugadores> jugadores = new List<Jugadores>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT * FROM Jugadores";
            jugadores = connection.Query<Jugadores>(query).ToList();
        }
        return jugadores;
    }
    public Jugadores obtenerPorId(int Id){
        Jugadores jugador = null;
        string query = "SELECT * FROM Jugadores WHERE Id = @pID";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            jugador = connection.QueryFirstOrDefault<Jugadores>(query, new {pId = Id});
        }
        return jugador;
    } 
    public List<Jugadores> obtenerCincoRandom(){
        List<Jugadores> jugadores = obtenerTodos();
        List<Jugadores> sobre = new List<Jugadores>();
        Random aleatorio = new Random();
        for(int i = 0; i < 5; i++){
            int numero = aleatorio.Next(0, jugadores.Count);
            sobre.Add(jugadores[numero]);
            jugadores.RemoveAt(numero);
        }
        return sobre;
    }
    public void pegarFiguritas(int IdJugador){
        string query = "UPDATE FiguritasUsuario SET Pegada = 1 WHERE IdJugadores = @idJugador";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Execute(query, new { IdJugador });
        }
    }
    public void guardarFigurita(int IdJugador){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT * FROM FiguritasUsuario WHERE IdJugadores = @IdJugador";
            FiguritasUsuario figurita = connection.QueryFirstOrDefault<FiguritasUsuario>(query, new { IdJugador });
            if(figurita == null){
                query = @"INSERT INTO FiguritasUsuario (Cantidad, Pegada, IdJugadores) VALUES (1, 0, @IdJugador)";
                connection.Execute(query, new { IdJugador });
            }
            else{
                query = @"UPDATE FiguritasUsuario SET Cantidad = Cantidad + 1 WHERE IdJugadores = @IdJugador";
                connection.Execute(query, new { IdJugador });
            }
        }
    }
    

}
