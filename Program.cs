using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerAndTeamProject
{
    interface IPlayer
    {
        void AddPlayer(Player player);
        bool RemovePlayer(int playerId);
        Player GetPlayerById(int playerId);
        List<Player> GetPlayersByName(string playerName);
        List<Player> GetAllPlayers();
    }

    class Program
    {
        static void Main()
        {
            IPlayer cricketTeam = new Team();


            cricketTeam.AddPlayer(new Player(1, "Narendra", 23));
            cricketTeam.AddPlayer(new Player(2, "Sai", 24));
            cricketTeam.AddPlayer(new Player(3, "Suresh", 25));

            DisplayMenu(cricketTeam);
        }

        static void DisplayMenu(IPlayer team)
        {
            while (true)
            {
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Remove Player");
                Console.WriteLine("3. Get Player by Id");
                Console.WriteLine("4. Get Player by Name");
                Console.WriteLine("5. Get All Players");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Player Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Player Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Player Age: ");
                        int age = int.Parse(Console.ReadLine());

                        team.AddPlayer(new Player(id, name, age));
                        Console.WriteLine("Player added successfully!");
                        break;

                    case 2:
                        Console.Write("Enter Player Id to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        if (team.RemovePlayer(removeId))
                            Console.WriteLine("Player removed successfully!");
                        else
                            Console.WriteLine("Player not found!");
                        break;

                    case 3:
                        Console.Write("Enter Player Id to get details: ");
                        int getById = int.Parse(Console.ReadLine());
                        Player playerById = team.GetPlayerById(getById);
                        if (playerById != null)
                            Console.WriteLine(playerById);
                        else
                            Console.WriteLine("Player not found!");
                        break;

                    case 4:
                        Console.Write("Enter Player Name to get details: ");
                        string getByName = Console.ReadLine();
                        List<Player> playersByName = team.GetPlayersByName(getByName);
                        if (playersByName.Any())
                            DisplayPlayers(playersByName);
                        else
                            Console.WriteLine("No players found with the given name!");
                        break;

                    case 5:
                        List<Player> allPlayers = team.GetAllPlayers();
                        if (allPlayers.Any())
                            DisplayPlayers(allPlayers);
                        else
                            Console.WriteLine("No players in the team!");
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayPlayers(List<Player> players)
        {
            Console.WriteLine("Player Details:");
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }
    }

    class Team : IPlayer
    {
        private List<Player> players;

        public Team()
        {
            players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (players.Count < 11)
            {
                players.Add(player);
            }
            else
            {
                Console.WriteLine("Cannot add more than 11 players to the team!");
            }
        }

        public bool RemovePlayer(int playerId)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Id == playerId);
            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                return true;
            }
            return false;
        }

        public Player GetPlayerById(int playerId)
        {
            return players.FirstOrDefault(p => p.Id == playerId);
        }

        public List<Player> GetPlayersByName(string playerName)
        {
            return players.Where(p => p.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Player> GetAllPlayers()
        {
            return players.ToList();
        }
    }

    class Player
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }

        public Player(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Player Id: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}