namespace HttpPassthroughWrapper.WithMapper;

public interface IMapper<TInput, TOutput>
{
    TOutput Map(TInput input);
}