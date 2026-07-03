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

    public Jugadores obtenerPorId(int ID){
        Jugadores jugador = null;
        string query = "SELECT * FROM Jugadores WHERE Numero = @pID";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            jugador = connection.QueryFirstOrDefault<Jugadores>(query, new {pID = ID});
        }
        return jugador;
    } 

    public List<Jugadores> abrirSobre (){
        List<Jugadores> jugadores = new List<Jugadores>();
        string query = "SELECT * FROM Jugadores";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            jugadores = connection.Query<Jugadores>(query).ToList();
        }
        List<Jugadores> sobre = new List<Jugadores>();
        for(int i = 0; i < 5; i++ ){
            Random aleatorio = new Random();
            int numero = aleatorio.Next(0, 20);
            sobre.Add(jugadores[numero]);
        }
        return sobre;
    }

    public int VerificarFiguritas (int id){
        string query = "SELECT * FROM FiguritasPegadas WHERE IdFigurita = @idFigurit";
        using(SqlConnection connection = new SqlConnection(_connectionString)){

        }
    }
    

    public void PegarFiguritas(int idJugador){
        string query = "INSERT INTO FiguritaUsuario (IdFigurita, IdAlbum) VALUES (@idFigurita, @idAlbum)";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
        

        }
    }

}
