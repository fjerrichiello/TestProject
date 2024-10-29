using Riok.Mapperly.Abstractions;

namespace Mapper;

[Mapper]
public partial class Mapper : IMapper
{
    public IEnumerable<TestRecord2> Map(TestRecord1 record1)
    {
        return record1.SubRecords.Select(x => new TestRecord2
        {
            Id = record1.Id, SubId = x.SubId, Value = x.SubValue
        }).ToList();
    }
}
