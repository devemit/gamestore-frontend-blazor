using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
	// get all games
	public async Task<GameSummary[]> GetGamesAsync() => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
	// add single game
	public async Task AddGameAsync(GameDetails game) => await httpClient.PostAsJsonAsync("games", game);
	// get one game
	public async Task<GameDetails> GetGameAsync(int id) => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Could not find a game");
	// update existing game
	public async Task UpdateGameAsync(GameDetails updatedGame) => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
	// delete game
	public async Task DeleteGameAsync(int id) => await httpClient.DeleteAsync($"games/{id}");
}


// helper functions/methods
// private Genre GetGenreById(string? id)
// {
// 	ArgumentException.ThrowIfNullOrEmpty(id);
// 	return genres.Single(genre => genre.Id == int.Parse(id));
// }
// public GameSummary GetGameSummaryById(int id)
// {
// 	var game = games.Find(game => game.Id == id);
// 	ArgumentNullException.ThrowIfNull(game);
// 	return game;
// }
