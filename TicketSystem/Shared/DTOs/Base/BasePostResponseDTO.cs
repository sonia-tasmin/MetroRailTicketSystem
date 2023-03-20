namespace TicketSystem.Shared.DTOs.Base;
public record BasePostResponseDTO<TKey, TEntity>
    where TKey : struct
    where TEntity : class
{
    public TKey Id { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public TEntity? Entity { get; set; }
}