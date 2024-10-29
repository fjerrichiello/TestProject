namespace Mapper;

public interface IMapper
{
    IEnumerable<TestRecord2> Map(TestRecord1 record1);
}
