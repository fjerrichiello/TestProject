using Dumpify;
using Mapper;

var mapper = new Mapper.Mapper();
var test1 = new TestRecord1(1, [new SubRecord(1, "1"), new SubRecord(2, "2")]);

var test2 = mapper.Map(test1).ToList();


test2.Dump();
