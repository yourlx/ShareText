using MongoDB.Driver;
using ShareText.WebApi.Exceptions;
using ShareText.WebApi.Models;

namespace ShareText.WebApi.Repository;

public class MongoNoteRepository : INoteRepository
{
    private readonly IMongoCollection<Note> _notes;

    public MongoNoteRepository(IMongoClient mongoClient, IConfiguration config)
    {
        var database = mongoClient.GetDatabase(config["DatabaseName"]);
        _notes = database.GetCollection<Note>("notes");

        var indexKeysDefinition = Builders<Note>.IndexKeys.Ascending(note => note.ExpirationTime);
        var indexOptions = new CreateIndexOptions { ExpireAfter = TimeSpan.FromSeconds(0) };
        var indexModel = new CreateIndexModel<Note>(indexKeysDefinition, indexOptions);

        _notes.Indexes.CreateOne(indexModel);
    }

    public async Task<Guid> CreateNoteAsync(Note note)
    {
        await _notes.InsertOneAsync(note);
        return note.Id;
    }

    public async Task<Note> GetNoteAsync(Guid id)
    {
        var note = await _notes.Find(note => note.Id == id).FirstOrDefaultAsync();

        if (note is null || DateTime.UtcNow > note.ExpirationTime)
        {
            throw new NoteNotFoundException($"Note with id = {id} was never" +
                                            " existed, expired or removed by admins!");
        }

        return note;
    }
}